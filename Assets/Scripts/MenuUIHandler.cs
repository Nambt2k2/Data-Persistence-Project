using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;

    private void Start()
    {
        Player.Instance.LoadHighScore();
        inputName.text = Player.Instance.nameMax;
    }

    public void InputName()
    {
        Player.Instance.nameP = inputName.text;
    }

    public void StartNew()
    {
        if(!string.IsNullOrWhiteSpace(Player.Instance.nameP))
            SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
# else
        Application.Quit();
#endif
    }
}
