using System;
using System.Collections.Generic;
using UnityEngine;
public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }

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
    
    public static Action OnClosePopup;

    public bool IsPopupOpen()
    {
        return _currentPopupSetter != null;
    }
    
    [SerializeField] private List<APopupSetter> popupSetters;

    private static APopupSetter _currentPopupSetter = null;
    
    public void ShowPopup(EPopupType popupType)
    {
        _currentPopupSetter = popupSetters.Find(x => x.PopupType == popupType);

        if (_currentPopupSetter == null)
        {
            Debug.LogError("Popup setter not found");
            return;
        }
        
        _currentPopupSetter.ShowPopup();
        GameManager.CursorStateManager.UnlockCursor();
    }

    public void SetPopup(EPopupType popupType, object data)
    {
        APopupSetter popup = popupSetters.Find(x => x.PopupType == popupType);

        if (popup == null)
        {
            Debug.LogError("Popup setter not found");
            return;
        }
        
        popup.SetPopup(data);
    }

    public void HidePopup()
    {
        if (_currentPopupSetter == null)
            return;
        
        _currentPopupSetter.HidePopup();
        _currentPopupSetter = null;
        GameManager.CursorStateManager.LockCursor();
        OnClosePopup?.Invoke();
    }
}
