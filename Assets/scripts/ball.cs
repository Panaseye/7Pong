using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ball : MonoBehaviour
{
    public GameSettings gameSettings;
    public spawnManager spawnManager;

    private Rigidbody2D ballRb;
    
    [SerializeField] float xForVector;
    [SerializeField] float yForVector;
    
    [SerializeField] float angleBorders = 0.35f;
  
    

    
    public bool boom = false;

    // Start is called before the first frame update
    void Awake()
    {
        
        gameSettings = Resources.Load<GameSettings>("gameSettings");
        spawnManager = GameObject.Find("spawnManager").GetComponent<spawnManager>();



        ballRb = GetComponent<Rigidbody2D>();
        spawnManager.countText.color = Color.white;

        // Apply the force to the ball with constant magnitude
        ballRb.AddForce(GetRandomVector() * gameSettings.forceMagnitude, ForceMode2D.Impulse);
        boom = false;

        gameSettings.count = 1;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < 5 && transform.position.x > -5)
        {
            Physics2D.IgnoreLayerCollision(6, 3,false);
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        bool ignoreCondition = (((ballRb.velocity.x > 0 && transform.position.x > 0f) || (ballRb.velocity.x < 0 && transform.position.x < 0f)));


        if ((collision.gameObject.CompareTag("goal") && !boom) || (collision.gameObject.CompareTag("stick") && boom && !ignoreCondition))
        {
            
            if (transform.position.x > 0)
            {
                gameSettings.leftScore++;
                Destroy(gameObject);
            }
            else gameSettings.rightScore++; Destroy(gameObject);

        }

        if ((collision.gameObject.CompareTag("stick")&& !boom) || (collision.gameObject.CompareTag("goal") && boom))
        {

            if (collision.gameObject.CompareTag("stick") && !boom && !ignoreCondition)
            
            {

                ballRb.velocity = GetNewBallTrajectory(collision) * (1+(float)gameSettings.count / gameSettings.speedMultiplayer) * gameSettings.forceMagnitude;

            }

            if (collision.gameObject.CompareTag("goal") && boom)
            {
                if (gameSettings.gameTypeTeleport) 
                {
                    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                }
                else Physics2D.IgnoreLayerCollision(6, 3);


            }

            gameSettings.count++;

            if (gameSettings.boomNum != 0)
            {
                if (IsMultipleOrContains(gameSettings.count))
                {
                    boom = true;
                    if (gameSettings.boomNumIndicator)
                    {
                       
                        spawnManager.countText.color = Color.red;
                        spawnManager.countText.text = "boom!";
                    }
                    
                    

                }
                else { 
                  boom = false;
                  
                  spawnManager.countText.color = Color.white;
                }
                    
                
                
                Debug.Log(gameSettings.count + "boom" + boom);

            }
            
                

            
            
            

        }
        


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("stick"))
        {
            Physics2D.IgnoreLayerCollision(6, 3, false);

        }
    }

    public bool IsMultipleOrContains(int number)
    {
        return number % gameSettings.boomNum == 0 || number.ToString().Contains(gameSettings.boomNum.ToString());
    }

    public Vector3 GetRandomVector()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), 0f).normalized;
        if (randomDirection.x < 0.1f && randomDirection.x > 0)
        {
            randomDirection.x += Random.Range(0.1f, 0.2f);
        }

        if (randomDirection.x > -0.1f && randomDirection.x < 0)
        {
            randomDirection.x -= Random.Range(0.1f, 0.2f);
        }
        return randomDirection;
    }
    public Vector2 GetNewBallTrajectory(Collision2D collision)
    {

        float hitPoint = ((transform.position.y - collision.transform.position.y) / (collision.collider.bounds.size.y));

        if (hitPoint < -angleBorders)
        {
            hitPoint = -angleBorders;
        }
        if (hitPoint > angleBorders)
        {
            hitPoint = angleBorders;
        }

        float angle = hitPoint * 180;

        xForVector = Mathf.Cos(angle * Mathf.Deg2Rad);
        yForVector = Mathf.Sin(angle * Mathf.Deg2Rad);


        if (transform.position.x > 0)
        {
            xForVector = -xForVector;

        }
        return new Vector2(xForVector, yForVector);
    }

}
