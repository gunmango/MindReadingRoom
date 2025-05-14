using System.Collections.Generic;
using UnityEngine;

public class BookLocator : MonoBehaviour
{
    [SerializeField] private List<BookShelf> bookShelves = new List<BookShelf>();
    
    public InteractableBook FindBookOrNull(string shelfID, int row)
    {
        BookShelf shelf = bookShelves.Find(x => x.ShelfID == shelfID);

        if (shelf == null)
        {
            Debug.LogError($"Wrong ShelfID: {shelfID}");
            return null;
        }

        if (shelf.books.Count < row)
        {
            Debug.LogError($"Shelf ID: {shelfID} is out of range");
            return null;
        }
        
        //책 찾음
        return shelf.books[row - 1];
    }
    public InteractableBook GetRandomInactiveBook(out BookLocationData bookLocationData) 
    {
        List<InteractableBook> books = new List<InteractableBook>();
        bookLocationData = new BookLocationData();
        
        foreach(var shelf in bookShelves)
        {
            bookLocationData.shelfID = shelf.ShelfID;
            
            foreach (var book in shelf.books)
            {
                if (book.gameObject.activeInHierarchy)
                    continue;
                
                books.Add(book);
            }
        }

        int index = Random.Range(0, books.Count);
        bookLocationData.row = index + 1;
        
        return books[Random.Range(0, books.Count)];
    }
}
