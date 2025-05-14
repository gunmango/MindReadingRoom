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
    public InteractableBook GetRandomInactiveBook() 
    {
        List<InteractableBook> books = new List<InteractableBook>();
        
        foreach(var shelf in bookShelves)
        {
            foreach (var book in shelf.books)
            {
                if (book.gameObject.activeInHierarchy)
                    continue;
                
                books.Add(book);
            }
        }

        return books[Random.Range(0, books.Count)];
    }
}
