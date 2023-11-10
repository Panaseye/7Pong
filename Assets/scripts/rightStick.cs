using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightStick : MonoBehaviour
{
    private float verticalInput;
    [SerializeField] float speed;
    [SerializeField] float border = 3.45f;

   
    public GameSettings gameSettings;

    // Start is called before the first frame update
    void Start()
    {
        gameSettings = Resources.Load<GameSettings>("gameSettings");
        

        speed = gameSettings.stickSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 0)
        {
            verticalInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

            LimitsControll();


        } else if (gameObject.transform.position.x < 0)
        {
            verticalInput = Input.GetAxis("VerticalLeft");

            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

            LimitsControll();

        }
        


    }

    private void LimitsControll()
    {
        if (transform.position.y > border)
        {
            transform.position = new Vector3(transform.position.x, border, transform.position.z);
        }

        if (transform.position.y < -border)
        {
            transform.position = new Vector3(transform.position.x, -border, transform.position.z);
        }


    }


}

