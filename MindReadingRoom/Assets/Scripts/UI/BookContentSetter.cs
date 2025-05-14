using UnityEngine;

public class BookContentSetter : APopupSetter
{
    [SerializeField] private BookContentUpdater updater = null;
    
    public override void ShowPopup()
    {
        updater.gameObject.SetActive(true);
    }

    public override void HidePopup()
    {
        updater.gameObject.SetActive(false);
    }

    public override void SetPopup(object data)
    {
        if (data is BookData bookData)
        {
            updater.SetImage(bookData.sprite);
            updater.SetContent(bookData.content);
        }
        else
        {
            Debug.LogWarning("BookContentSetter: data is not a BookData");
        }
    }
}
