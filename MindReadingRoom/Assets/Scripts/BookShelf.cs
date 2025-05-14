using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class BookShelf : MonoBehaviour
{
    [SerializeField] private string shelfID;
    public string ShelfID { get => shelfID; }
    
    public List<InteractableBook> books = new List<InteractableBook>();

    private void Start()
    {
        for (int i = 0; i < books.Count; i++)
        {
            books[i].location.shelfID = ShelfID;
            books[i].location.row = i + 1;
        }
    }
}
