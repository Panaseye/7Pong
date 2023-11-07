using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class spawnManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI leftScoreText;
    [SerializeField] TextMeshProUGUI rightScoreText;
    [SerializeField] TextMeshProUGUI countText;

    public int leftScore ;
    public int rightScore ;
    public int count;
    public GameObject ballPrefab;
    public Vector2 spawnPoint = Vector2.zero;
    public float delayBeforeSpawn = 2f;

    public gameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManager = FindObjectOfType<gameManager>();
        StartCoroutine(CheckAndSpawnBall());

        
    }

    // Update is called once per frame
    void Update()
    {

        leftScore = gameManager.leftScore;
        rightScore = gameManager.rightScore;
        count = gameManager.count;

        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
        countText.text = count.ToString();
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
}
