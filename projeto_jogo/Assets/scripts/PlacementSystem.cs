using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;

    [SerializeField]
    private LayerMask placementlayermask;

    [SerializeField]
    private GameObject mouseIndicator;

    [SerializeField]
    private InputManager inputManager;

    // Para construção (no PlacementSystem)
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, placementlayermask))
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    // Para seleção de prédios
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, placementlayermask))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Construcao"))
            {
                Predios predio = hitObject.GetComponent<Predios>();
                if (predio != null)
                {
                    predio.Selecionar();
                }
            }
        }
    }
}
