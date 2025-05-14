using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BookManager : MonoBehaviour
{
    [SerializeField] private BookLocator bookLocator;

    public void Initialize()
    {
        //저장된 책 위치들 받아오기
        GameManager.WebManager.SendGetBookLocations(FillInitialBooks);
    }
    
    public void FillInitialBooks(List<BookLocationData> books)
    {
        foreach (BookLocationData bookLocation in books)
        {
            InteractableBook book = bookLocator.FindBookOrNull(bookLocation.shelfID, bookLocation.row);
            
            if (book != null)
            {
                //있던 책 세팅
                book.gameObject.SetActive(true);
            }
        }
    }

    public void CreateRandomBook(string userInput)
    {
        InteractableBook book = bookLocator.GetRandomInactiveBook(out var bookLocationData);
        
        //책위치와 고민을 백엔드에 전달
        GameManager.WebManager.SendBookLocationAndUserInput(bookLocationData, userInput);
        
        book.GlowBook();
    }
}
