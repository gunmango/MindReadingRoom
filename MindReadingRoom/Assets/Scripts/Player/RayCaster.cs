using Unity.VisualScripting;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public float rayDistance = 5f;
    public LayerMask layerMask; // 특정 레이어만 감지할 수 있게 설정 가능

    private GameObject collidedObject = null;
    
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<Interactable>()?.Interact();
            }
            
            if (collidedObject == hit.collider.gameObject)
                return;
            
            if(collidedObject != null)
                collidedObject.GetComponent<OutLineableObject>()?.HideOutline();
            
            collidedObject = hit.collider.gameObject;
            
            // Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
            // Debug.Log("레이가 맞은 물체: " + hit.collider.name);
            
            collidedObject.GetComponent<OutLineableObject>()?.ShowOutline();
        }
        else
        {
            if (collidedObject == null)
                return;
            
            collidedObject.GetComponent<OutLineableObject>()?.HideOutline();
            collidedObject = null;
        }

    }
}