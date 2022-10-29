using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuHandler : MonoBehaviour
{
    public InputField nameInputField;
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score: " + GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.bestScore;
        nameInputField.text = GameManager.Instance.bestPlayerName;
    }

    public void StartGame()
    {
        GameManager.Instance.currentPlayerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }


}
