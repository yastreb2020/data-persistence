using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    string playerName;
    [SerializeField] TMP_InputField nameInputField;
    Color neutralInputColor = new Color32(255, 255, 255, 255);
    Color wrongInputColor = new Color32(239, 170, 170, 134);
    //or  wrongInputColor = new Color(0.9372549f, 0.6666667f, 0.6666667f, 0.5254902f);
    // "EFAAAA"

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        if (playerName != null)
        {
            SceneManager.LoadScene("main");
        }
        else
        {
            nameInputField.text = "";
        }
    }

    public void CheckEnteredName()
    {
        if (nameInputField.text.Length > 1) { 
            playerName = nameInputField.text;
            nameInputField.image.color = neutralInputColor;
        }
        else
        {
            nameInputField.image.color = wrongInputColor;
            playerName = null;
        }
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
