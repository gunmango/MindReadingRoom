using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutLineableObject : MonoBehaviour
{ 
    private Outline outline = null;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void Start()
    {
        outline.enabled = false;
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
