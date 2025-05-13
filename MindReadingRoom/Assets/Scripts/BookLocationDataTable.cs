using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BookLocationData
{
    public string bookId;             // 고유 ID 또는 timestamp
    public string shelfID;          // 책장이 몇 번인지
    public int row;              // 몇 층 선반인지
}

[CreateAssetMenu(fileName = "BookLactionDataTable", menuName = "Book Location")]
public class BookLocationDataTable : ScriptableObject
{
    public List<BookLocationData> bookLocationData;
}
