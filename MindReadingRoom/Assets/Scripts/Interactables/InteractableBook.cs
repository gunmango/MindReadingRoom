using UnityEngine;
using System.Collections;

public class InteractableBook : OutLineableObject, Interactable
{
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
        StartCoroutine(GetBookDataCo());
    }

    public void GlowBook()
    {
        
    }

    private IEnumerator GetBookDataCo()
    {
        bookData = new BookData();
        //책데이터 가져오기
        yield return null;
        GameManager.PopupManager.SetPopup(popupType, bookData);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
