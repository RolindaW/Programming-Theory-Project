using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const int MAX_ENEMY_NUMBER = 10;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private List<GameObject> enemyPrefabs;

    private GameObject enemies;
    private int score;
    
    public bool IsGameActive { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        IsGameActive = true;

        enemies = new GameObject("Enemies");
        enemies.transform.position = Vector3.zero;

        AddScore(0);
        if (ConfigurationManager.Instance != null)
        {
            UpdateNameText(ConfigurationManager.Instance.Name);
            UpdateHighScoreText(ConfigurationManager.Instance.HighScoreName, ConfigurationManager.Instance.HighScoreValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameActive)
        {
            // Spawn required enemies
            int pendingEnemies = MAX_ENEMY_NUMBER - enemies.transform.childCount;
            if (pendingEnemies > 0)
            {
                for (int i = 0; i < pendingEnemies; i++)
                {
                    SpawnRandomEnemy();
                }
            }
        }
    }

    public void SpawnRandomEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Count);
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject enemyPrefab = enemyPrefabs[index];
        
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        enemy.transform.SetParent(enemies.transform);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float xSpawnBound = 18.5f;
        float zSpawnBound = 18.5f;

        return new Vector3(Random.Range(-xSpawnBound, xSpawnBound), 0.5f, Random.Range(-zSpawnBound, zSpawnBound));
    }

    public void GameOver()
    {
        IsGameActive = false;

        if (ConfigurationManager.Instance != null)
        {
            if (score >= ConfigurationManager.Instance.HighScoreValue)
            {
                ConfigurationManager.Instance.HighScoreValue = score;
                ConfigurationManager.Instance.HighScoreName = ConfigurationManager.Instance.Name;
                ConfigurationManager.Instance.SaveData();
            }
        }

        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        UpdateScoreText(score);
    }
    
    private void UpdateScoreText(int score)
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    public void UpdateHealthText(int health)
    {
        healthText.text = string.Format("Health: {0}", health);
    }
    
    private void UpdateNameText(string name)
    {
        nameText.text = name;
    }
    
    private void UpdateHighScoreText(string highScoreName, int highScoreValue)
    {
        highScoreText.text = string.Format("High Score: {0} - {1}", highScoreName, highScoreValue);
    }
}
