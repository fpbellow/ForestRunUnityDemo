using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleTree;
    public GameObject[] specialObstacles;

    private GameManager gameManager;
    private Vector3 spawnPosTree = new Vector3(30, .6f, -1.8f);
    private Vector3 spawnPosSpec = new Vector3(30, 5.384928f, -5.71561f);

    private float spawnDelay = 3f;
    private float timeRemaining = 15;
    private int difficultyTier = 0;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BeginSpawning()
    {
        StartCoroutine(TimerRoutine());
        StartCoroutine(SpawnObstacleRoutine());
    }

 

    IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(timeRemaining);
        difficultyTier++;
        if (difficultyTier == 1)
        {
            spawnDelay = 2f;
        }
        if (difficultyTier == 2)
        {
            spawnDelay = 1.5f;
        }
        if (difficultyTier < 4)
        {
            timeRemaining = 15 * (difficultyTier + 1);
            StartCoroutine(TimerRoutine());
        }
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnDelay);
            int specialObsChance = Random.Range(1, 100);
            switch (difficultyTier)
            {
                case 0:
                    Instantiate(obstacleTree, spawnPosTree, obstacleTree.transform.rotation);
                    break;
                case 1:
                    Instantiate(obstacleTree, spawnPosTree, obstacleTree.transform.rotation);
                    break;
                case 2:
                    if (specialObsChance > 80)
                    {
                        Instantiate(specialObstacles[0], spawnPosSpec, specialObstacles[0].transform.rotation);
                    }
                    else
                    {
                        Instantiate(obstacleTree, spawnPosTree, obstacleTree.transform.rotation);
                    }
                    break;
                case 3:
                    if (specialObsChance > 50)
                    {
                        Instantiate(specialObstacles[0], spawnPosSpec, specialObstacles[0].transform.rotation);
                    }
                    else
                    {
                        Instantiate(obstacleTree, spawnPosTree, obstacleTree.transform.rotation);
                    }
                    break;
            }
        }
    }
    
}
