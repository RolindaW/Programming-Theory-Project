using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    
    public bool IsGameActive { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        IsGameActive = true;
        
        if (ConfigurationManager.Instance != null)
        {
            nameText.text = ConfigurationManager.Instance.Name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
