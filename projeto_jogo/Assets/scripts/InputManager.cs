using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;

    [SerializeField]
    private LayerMask placementlayermask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clique esquerdo
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

            if (hitObject.CompareTag("Construcao")) // Certifique-se de que os prédios têm essa tag
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
