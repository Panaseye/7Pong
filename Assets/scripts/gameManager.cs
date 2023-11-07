using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject headline;



    public int boomNum = 7;
    public float stickSpeed = 8;

    public float speedMultiplayer = 10f;
    public float forceMagnitude = 10f;


    public int leftScore = 0;
    public int rightScore = 0;
    public int count;
    private bool isPaused = false;
    

    public static gameManager Instance { get; private set; }

    // Start is called before the first frame update
    void awake()
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
        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            PauseGame();

        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            ResumeGame();
        }


       
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);

    }

    public void SettingsToggle()
    {
        if (headline.activeSelf)
        {
            headline.SetActive(false);
            settings.SetActive(true);
        }
        else
        {
            headline.SetActive(true);
            settings.SetActive(false);
        }
    }
        
    public void BackToMenu()
    {
          SceneManager.LoadScene(1);

    }

    
}
