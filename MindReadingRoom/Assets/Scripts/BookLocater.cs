using System.Collections.Generic;
using UnityEngine;

public class BookLocater : MonoBehaviour
{
    [SerializeField] private List<BookShelf> bookShelves = new List<BookShelf>();

    
    public void FillBook(string shelfID, int row)
    {
        BookShelf shelf = bookShelves.Find(x => x.ShelfID == shelfID);

        if (shelf == null)
        {
            Debug.LogError($"Wrong ShelfID: {shelfID}");
            return;
        }

        if (shelf.books.Count < row)
        {
            Debug.LogError($"Shelf ID: {shelfID} is out of range");
            return;
        }
        
        shelf.books[row - 1].gameObject.SetActive(true);
    }
}
