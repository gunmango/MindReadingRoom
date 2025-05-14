using System;
using System.Collections.Generic;
using UnityEngine;

public class WebManager : MonoBehaviour
{
    private DataManager dataManager;
    void Start()
    {
        dataManager = GameManager.DataManager;
    }

    // 저장된 모든 책 위치 가져오기
    public void SendGetBookLocations(Action<List<BookLocationData>> callback)
    {
        Debug.Log("SendGetBookLocations");
        //StartCoroutine(GetBookList.Send(dataManager.Nickname, callback));
    }

    // 책정보 (이미지, 시) 가져오기
    public void SendGetBookContent(BookLocationData location, Action<BookData> callback)
    {
        Debug.Log("GetBookContent");
        StartCoroutine(GetBookContent.Send(dataManager.Nickname, location, callback));

        BookData book = new BookData();
        callback.Invoke(book);
    }

    // 책 위치와, 유저 고민 백엔드로
    public void SendBookLocationAndUserInput(BookLocationData location, string input)
    {
        Debug.Log("SendBookLocationAndUserInput");
        //StartCoroutine(PostContent.Send(input, location.shelfID, location.row, dataManager.Nickname));
    }
}
