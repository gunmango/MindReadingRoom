using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class BookManager : MonoBehaviour
{
    public static BookManager Instance { get; private set; }

    private void Awake()
    {
        // 싱글톤 인스턴스가 없으면 등록
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환에도 살아남게
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 제거
        }
    }
    
    [SerializeField] private BookLocator bookLocator;

    public void Start()
    {
        //저장된 책 위치들 받아오기
        GameManager.WebManager.SendGetBookLocations(FillInitialBooks);
    }
    
    public void FillInitialBooks(List<BookLocationData> books)
    {
        if (books.Count == 0)
            return;
        
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
        InteractableBook book = bookLocator.GetRandomInactiveBook();
        
        //책위치와 고민을 백엔드에 전달
        GameManager.WebManager.SendBookLocationAndUserInput(book.location, userInput);
        
        book.gameObject.SetActive(true);

        PopupManager.Instance.ShowNotice(EPopupType.LocationNotice, book.location);
    }
}
