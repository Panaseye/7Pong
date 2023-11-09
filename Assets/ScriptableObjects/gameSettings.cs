using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{

    public bool boomNumIndicator = true;
    public bool showBoomNum = true;

    


    public int boomNum = 7;

    public float stickSpeed = 8;

    public float speedMultiplayer = 10f;
    public float forceMagnitude = 10f;

    public int leftScore = 0;
    public int rightScore = 0;
    public int count;

  
    

   
}