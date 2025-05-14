using UnityEngine;

public class InteractableLibrarian : MonoBehaviour, Interactable
{
    public void Interact()
    {
        ShowConfessionInputPopup();
    }

    private void ShowConfessionInputPopup()
    {
        PopupManager.Instance.ShowPopup(EPopupType.ConfessionInput);
    }
}
