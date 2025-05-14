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
        
        GameManager.PopupManager.ShowPopup(popupType);
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
        GameManager.PopupManager.SetPopup(popupType, bookData);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
