using UnityEngine;

public class ConfessionInputSetter : MonoBehaviour
{
    [SerializeField] private ConfessionInputUpdater _updater = null;

    private string userInput = "";
    private void Awake()
    {
        _updater.gameObject.SetActive(false);
    }

    public void ShowPopup()
    {
        _updater.gameObject.SetActive(true);
    }

    public void OnClickSubmit()
    {
        userInput = _updater.InputField.text;
        _updater.InputField.text = "";
        _updater.gameObject.SetActive(false);
        
        //userInput 서버전달
    }
}
