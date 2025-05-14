using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BookManager : MonoBehaviour
{
    [SerializeField] private BookLocator bookLocator;

    public void Initialize()
    {
        List<BookLocationData> bookLocations = new List<BookLocationData>();
        
        //저장된 책 위치들 받아오기
        
        FillInitialBooks(bookLocations);
    }
    
    public void FillInitialBooks(List<BookLocationData> books)
    {
        foreach (BookLocationData bookLocation in books)
        {
            InteractableBook book = bookLocator.FindBookOrNull(bookLocation.shelfID, bookLocation.row);
            
            if (book != null)
            {
                //있던책 세팅
                book.gameObject.SetActive(true);
            }
        }
    }

    public void CreateRandomBook(string userInput)
    {
        BookLocationData bookLocationData = new BookLocationData();
        InteractableBook book = bookLocator.GetRandomInactiveBook(out bookLocationData);
        
        //책위치와 고민을 백엔드에 전달
        book.GlowBook();
    }
}
