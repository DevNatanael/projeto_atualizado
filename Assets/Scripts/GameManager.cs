using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text liveText;

    public float startWait;
    public GameObject[] enemies;
    public Boundary boundary;
    public Vector2 spawnWait;
    public int enemyCountMax = 10;
    public float spawnWaitMin;
    public float waveWait;
    public float waveWaitMin;
    public bool gameOver = false;
    private int enemyCount = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWait);
        while(!gameOver)
        {
            for(int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = enemies[Random.Range(0,enemies.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(boundary.xMin,boundary.xMax), boundary.yMin, 0);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(spawnWait.x,spawnWait.y));
            }

            enemyCount++;

            if(enemyCount >= enemyCountMax)
            {
                enemyCount = enemyCountMax;
                spawnWait.x -= 0.1f;
                spawnWait.y -= 0.1f;

                if(spawnWait.y <= spawnWaitMin)
                {
                    spawnWait.y = spawnWaitMin;
                }

                if(spawnWait.x <= spawnWaitMin)
                {
                    spawnWait.x = spawnWaitMin;
                }

                yield return new WaitForSeconds(waveWait);
                waveWait -= 0.1f;

                if(waveWait <= waveWaitMin)
                {
                    waveWait = waveWaitMin;
                }
            }
        }
    }

    public void SetLivesText(int lives)
    {
        liveText.text = "X" + lives.ToString();
    }
}
