using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    RaycastHit hitInfo;
    [SerializeField]
    private Camera sceneCamera;

    private Vector3 lastposition;

    [SerializeField]
    private LayerMask placementlayermask;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, placementlayermask))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            
            lastposition = hit.point;
        }
        return lastposition;
    }    

}
