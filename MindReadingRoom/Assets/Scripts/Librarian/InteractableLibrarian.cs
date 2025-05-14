using UnityEngine;

public class InteractableLibrarian : MonoBehaviour, Interactable
{
    public void Interact()
    {
        ShowConfessionInputPopup();
    }

    private void ShowConfessionInputPopup()
    {
        GameManager.PopupManager.ShowPopup(EPopupType.ConfessionInput);
    }
}
