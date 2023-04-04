using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public TMP_Text countdownText;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    void Update ()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        countdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
