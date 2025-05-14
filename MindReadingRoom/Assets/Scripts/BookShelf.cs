using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BookShelf : MonoBehaviour
{
    [SerializeField] private string shelfID;
    public string ShelfID { get => shelfID; }
    
    public List<InteractableBook> books = new List<InteractableBook>();
}
