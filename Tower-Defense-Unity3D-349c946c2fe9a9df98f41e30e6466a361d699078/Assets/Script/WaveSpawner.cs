using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform ennemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timebetweenWaves = 5f;

    private float countdown = 2f;

    [SerializeField]
    private Text wavesCountdownTimer;


    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
           StartCoroutine(SpawnWave());
            countdown = timebetweenWaves;
        }

        countdown -= Time.deltaTime;
        wavesCountdownTimer.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;


        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy() 
    {
        Instantiate(ennemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}