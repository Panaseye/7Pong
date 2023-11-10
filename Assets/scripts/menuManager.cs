using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class menuManager : MonoBehaviour
{

    [SerializeField] GameObject settings;
    [SerializeField] GameObject headline;

    [SerializeField] Slider boomNumInput;
    [SerializeField] TextMeshProUGUI boomNumText;

    [SerializeField] Slider ballSpeedInput;
    [SerializeField] TextMeshProUGUI ballSpeedText;

    [SerializeField] Toggle gameTypeInput;
    [SerializeField] TextMeshProUGUI gameTypeInputText;


    [SerializeField] Toggle showBoomNumToggle;
    [SerializeField] Toggle BoomNumIndicatorToggle;

    public GameSettings gameSettings;


    // Start is called before the first frame update
    void Start()
    {
        gameSettings = Resources.Load<GameSettings>("gameSettings");
        KeepSettings();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void BoomNumChange()
    {
        if ((int)boomNumInput.value == 0)
        {
            gameSettings.boomNum = 0;
            boomNumText.text = ("no boom");
            
        }
        else
        {
            gameSettings.boomNum = ((int)boomNumInput.value);
            boomNumText.text = boomNumInput.value.ToString();
        }


        Debug.Log(gameSettings.boomNum);
    }

    public void BallSpeedChange()
    {
        ballSpeedText.text = (ballSpeedInput.value.ToString()) ;
        gameSettings.forceMagnitude = (ballSpeedInput.value) * 4;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);

    }

    public void ShowBoomNum()
    {
        gameSettings.showBoomNum = showBoomNumToggle.isOn;
    }

    public void BoomNumIndicator()
    {
        gameSettings.boomNumIndicator = BoomNumIndicatorToggle.isOn;
    }
    public void KeepSettings()
    {
        boomNumInput.value = gameSettings.boomNum;
        showBoomNumToggle.isOn = gameSettings.showBoomNum;
        BoomNumIndicatorToggle.isOn = gameSettings.boomNumIndicator;
        ballSpeedInput.value = gameSettings.forceMagnitude / 4;
        gameTypeInput.isOn = gameSettings.gameTypeTeleport;

    }

    public void ResetScore()
    {
        gameSettings.leftScore = 0;
        gameSettings.rightScore = 0;
    }

    public void GameType()
    {
        gameSettings.gameTypeTeleport = gameTypeInput.isOn;
        if (gameTypeInput.isOn)
        {
            gameTypeInputText.text = "teleport ball";
        } else gameTypeInputText.text = "squash ball";

    }

}
