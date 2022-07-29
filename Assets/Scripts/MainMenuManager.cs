using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    private const float FOOTER_MESSAGE_DISPLAY_TIME = 2.5f;
    private const string ERROR_NOT_VALID_NAME = "'{0}' is not a valid name.";
    
    [SerializeField] private TextMeshProUGUI footerText;
    [SerializeField] private TMP_InputField nameInput;
    
    public void StartGame()
    {
        if (ConfigurationManager.Instance.IsValidName(nameInput.text))
        {
            ConfigurationManager.Instance.Name = nameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            string message = string.Format(ERROR_NOT_VALID_NAME, nameInput.text);
            StartCoroutine(DisplayTimedMessageOnFooter(message));
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    private IEnumerator DisplayTimedMessageOnFooter(string message)
    {
        footerText.text = message;
        footerText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(FOOTER_MESSAGE_DISPLAY_TIME);
        
        footerText.gameObject.SetActive(false);
        footerText.text = "";
    }
}
