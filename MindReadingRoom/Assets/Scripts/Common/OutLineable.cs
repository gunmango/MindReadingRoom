using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutLineableObject : MonoBehaviour
{ 
    private Outline outline;

    private void Awake()
    {
        Debug.Log($"{gameObject.name}: Awake");
        outline = GetComponent<Outline>();
    }
    
    public void ShowOutline()
    {
        outline.enabled = true;
    }

    public void HideOutline()
    {
        outline.enabled = false;
    }
}
