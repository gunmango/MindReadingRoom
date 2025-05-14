using System;
using System.Collections.Generic;
using UnityEngine;
public class PopupManager : MonoBehaviour
{
    public Action OnClosePopup;

    public bool IsPopupOpen()
    {
        return _currentPopupSetter != null;
    }
    
    [SerializeField] private List<APopupSetter> popupSetters;

    private APopupSetter _currentPopupSetter = null;
    
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
        GameManager.CursorStateManager.UnlockCursor();
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
