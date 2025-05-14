using UnityEngine;
using System.Collections;

public class InteractableBook : OutLineableObject, Interactable
{
    public BookLocationData location;
    
    private static EPopupType popupType = EPopupType.Book;

    private BookData bookData = null;
    
    public void Interact()
    {
        if(bookData == null)
            GetBookData();
        
        PopupManager.Instance.ShowPopup(popupType);
    }

    private void GetBookData()
    {
        GameManager.WebManager.SendGetBookContent(location, SetBookData);
    }

    public void GlowBook()
    {
        
    }

    public void SetBookData(BookData bookData)
    {
        this.bookData = bookData;
        PopupManager.Instance.SetPopup(popupType, bookData);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
