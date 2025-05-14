using UnityEngine;

public abstract class APopupSetter : MonoBehaviour
{
    [SerializeField] private EPopupType popupType = EPopupType.None;
    public EPopupType PopupType => popupType;
    
    public abstract void ShowPopup();
    public abstract void HidePopup();
}
