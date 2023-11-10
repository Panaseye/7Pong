using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    
    
    



   
    
    

    public static gameManager Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    

    // Update is called once per frame
    void Update()
    {
       

       

       
    }
    
   

   

    
}
