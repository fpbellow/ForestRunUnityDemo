using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public Button restartButton;

    private SpawnManager spawnManager;
    private PlayerController playerController;
    public bool isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("PlayerChar").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnManager.BeginSpawning();
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartGame();
    }
}
