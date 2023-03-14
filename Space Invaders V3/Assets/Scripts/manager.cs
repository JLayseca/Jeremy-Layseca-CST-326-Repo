using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public float columns = 5;
    private float rows = 5;
    public float spawnHeight = 15;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI HighScore;
    float scoreCount;
    float HighestScore;
    public string creditsSceneName;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        enemySpawner();
        enemy.deathEvent += ScoreCounter;
        specialEnemy.deathEvent += ScoreCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            SceneManager.LoadScene(creditsSceneName, LoadSceneMode.Single);
        }
        
        if (GameObject.Find("Enemy 1(Clone)") == null && GameObject.Find("Enemy 2(Clone)") == null && GameObject.Find("Enemy 3(Clone)") == null)
        {
            SceneManager.LoadScene(creditsSceneName, LoadSceneMode.Single);
        }
    }

    void enemySpawner()
    {   
        var currentRow = 0f;
        var currentColumn = 0f;
        for(float i=0; i < rows; i++)
        {
            currentRow = i;
            for(float k = -1 * columns; k < 0; k++)
            {
                currentColumn = k;
                if (currentRow == 0)
                {
                    GameObject Enemy = Instantiate(enemy1, new Vector3(currentColumn, spawnHeight - currentRow, -5), Quaternion.identity);
                }

                else if (currentRow <= 2 && currentRow > 0)
                {
                    GameObject Enemy = Instantiate(enemy2, new Vector3(currentColumn, spawnHeight - currentRow, -5), Quaternion.identity);
                }

                else if(currentRow > 2)
                {
                    GameObject Enemy = Instantiate(enemy3, new Vector3(currentColumn, spawnHeight - currentRow, -5), Quaternion.identity);
                }
            }
        }

        GameObject SpecialEnemy = Instantiate (enemy4, new Vector3(0f, 9.5f, -5f), Quaternion.identity);
    }

    public void ScoreCounter(float pointValue)
    {
        scoreCount += pointValue;
        if (scoreCount < 100){
            CurrentScore.text = $"Score: 00{scoreCount}";
        }
        else if (scoreCount < 1000){
            CurrentScore.text = $"Score: 0{scoreCount}";
        }
        else if (scoreCount >= 1000){
            CurrentScore.text = $"Score: {scoreCount}";
        }
        
                    
        HighScoreCompare();
    }

    public void HighScoreCompare()
    {
        HighestScore = PlayerPrefs.GetFloat("HighScore", 0);
        if(scoreCount > HighestScore)
        {
            PlayerPrefs.SetFloat("HighScore", scoreCount);
            HighestScore = scoreCount;
        }
        else if (HighestScore < 100){
            HighScore.text = $"High Score: 00{HighestScore}";
        }
        else if (HighestScore < 1000){
            HighScore.text = $"High Score: 0{HighestScore}";
        }
        else if (HighestScore >= 1000){
            HighScore.text = $"High Score: {HighestScore}";
        }
    }

}
