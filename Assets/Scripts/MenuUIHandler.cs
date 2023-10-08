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
        UpdateBestScoreText();
    }

    private void UpdateBestScoreText()
    {
        DataSaver.SaveData bestScoreData = DataSaver.instance.LoadDataFile();
        if (bestScoreData != null)
        {
            bestScoreText.text = $"Best Score:{bestScoreData.bestPlayerName}:{bestScoreData.bestScore}";
        }
    }

    public void StartButton()
    {
        if (DataSaver.instance.playerName != null)
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
            DataSaver.instance.playerName = nameInputField.text;
            nameInputField.image.color = neutralInputColor;
        }
        else
        {
            nameInputField.image.color = wrongInputColor;
            DataSaver.instance.playerName = null;
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
