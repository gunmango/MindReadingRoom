using UnityEngine;
using UnityEngine.UI;
 using TMPro;   
using UnityEngine.SceneManagement;

public class TitleInput : MonoBehaviour
{
    public TMP_InputField inputField;

    void OnSendButtonClicked()
    {
        string userInput = inputField.text.Trim();  
        if (string.IsNullOrEmpty(userInput))
        {
            Debug.LogWarning("Input is empty!");
            return;
        }

        GameManager.DataManager.Nickname = userInput;
        Debug.Log(GameManager.DataManager.Nickname);

        SceneManager.LoadScene("SampleScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSendButtonClicked();
        }
    }
}
