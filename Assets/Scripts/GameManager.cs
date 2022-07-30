using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const int MAX_ENEMY_NUMBER = 5;
    
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private List<GameObject> enemyPrefabs;

    private GameObject enemies;
    
    public bool IsGameActive { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        IsGameActive = true;

        enemies = new GameObject("Enemies");
        enemies.transform.position = Vector3.zero;

        if (ConfigurationManager.Instance != null)
        {
            nameText.text = ConfigurationManager.Instance.Name;
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
}
