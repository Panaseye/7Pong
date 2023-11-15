using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour
{

    public GameSettings gameSettings;

    [SerializeField] GameObject pauseScreen;
    [SerializeField] TextMeshProUGUI leftScoreText;
    [SerializeField] TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI boomNumText;

    private bool isPaused = false;

    public GameObject currentBall;
    
    public GameObject ballPrefab;
    public Vector2 spawnPoint = Vector2.zero;
    public float delayBeforeSpawn = 2f;

    
    // Start is called before the first frame update
    void Start()
    {
        gameSettings = Resources.Load<GameSettings>("gameSettings");
        StartCoroutine(CheckAndSpawnBall());
        if (gameSettings.showBoomNum)
        {
            boomNumText.gameObject.SetActive(true);
            boomNumText.text = "Boom's at: " + gameSettings.boomNum.ToString();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
       
        

        leftScoreText.text = gameSettings.leftScore.ToString();
        rightScoreText.text = gameSettings.rightScore.ToString();
        
        countText.text = gameSettings.count.ToString();
        

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

    IEnumerator CheckAndSpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBeforeSpawn);

            // Check if there's no ball on the pitch
            if (GameObject.FindWithTag("ball") == null)
            {
                // Instantiate a new ball at the spawn point
                Instantiate(ballPrefab, spawnPoint, Quaternion.identity);

                
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
        ResumeGame();

    }
}
