using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformCount = 300;
    public Transform player; 
    public GameObject gameOverUI; 
    public GameObject RestartButton; 
    public TextMeshProUGUI scoreText; 

    private float minY; 
    private float highestY = 0f;
    private int score = 0;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(2f, 3f);
            spawnPosition.x = Random.Range(-3f, 5f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        minY = player.position.y - 3f; 
    }

    void Update()
    {
        if (player.position.y > highestY)
        {
            highestY = player.position.y;
            score = Mathf.FloorToInt(highestY); 
            scoreText.text = "Score: " + score.ToString();
        }

        if (player.position.y < minY)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true); 
        RestartButton.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
