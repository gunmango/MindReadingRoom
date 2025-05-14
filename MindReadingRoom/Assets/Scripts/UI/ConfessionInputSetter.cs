using UnityEngine;

public class ConfessionInputSetter : APopupSetter
{
    [SerializeField] private ConfessionInputUpdater _updater = null;

    private string userInput = "";
    private void Awake()
    {
        _updater.gameObject.SetActive(false);
    }

    public override void ShowPopup()
    {
        _updater.gameObject.SetActive(true);
        _updater.InputField.ActivateInputField(); // 실행 시 자동 포커스
    }

    public override void HidePopup()
    {
        userInput = _updater.InputField.text;
        
        GameManager.BookManager.CreateRandomBook(userInput);
        
        _updater.InputField.text = "";
        _updater.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_updater.gameObject.activeInHierarchy == false)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PopupManager.Instance.HidePopup();
        }
        
        
    }
}
