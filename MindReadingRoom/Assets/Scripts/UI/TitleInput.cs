using UnityEngine;
using UnityEngine.UI;
 using TMPro;   
using UnityEngine.SceneManagement;

public class TitleInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button sendButton;         
    void Start()
    {
        // 버튼 클릭 시 OnSendButtonClicked() 호출
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }

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
}
