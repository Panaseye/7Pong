using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightStick : MonoBehaviour
{
    private float verticalInput;
    [SerializeField] float speed;
    [SerializeField] float border = 3.45f;

    public gameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManager = FindObjectOfType<gameManager>();

        speed = gameManager.stickSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        if (transform.position.y > border )
        {
            transform.position = new Vector3(transform.position.x, border, transform.position.z);
        }

        if (transform.position.y < - border)
        {
            transform.position = new Vector3(transform.position.x, -border, transform.position.z);
        }
    }

   
              
    
}

