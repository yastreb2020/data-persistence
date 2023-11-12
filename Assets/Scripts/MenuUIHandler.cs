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
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TextMeshProUGUI bestScoreText;
    Color neutralInputColor = new Color32(255, 255, 255, 255);
    Color wrongInputColor = new Color32(239, 170, 170, 134);
    //or  wrongInputColor = new Color(0.9372549f, 0.6666667f, 0.6666667f, 0.5254902f);
    // "EFAAAA"

    private void Start()
    {
        bestScoreText.text = DataSaver.instance.NewBestScoreText();
        nameInputField.text = DataSaver.saveData.currentPlayer;
    }

    public void StartButton()
    {
        if (nameInputField.text != "")
        {            
            SceneManager.LoadScene("main");
        }
    }

    public void CheckEnteredName()
    {
        if (nameInputField.text.Length > 1) {
            DataSaver.saveData.currentPlayer = nameInputField.text;
            nameInputField.image.color = neutralInputColor;
        }
        else
        {
            nameInputField.image.color = wrongInputColor;
            DataSaver.saveData.currentPlayer = "";
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
