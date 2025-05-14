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
}
