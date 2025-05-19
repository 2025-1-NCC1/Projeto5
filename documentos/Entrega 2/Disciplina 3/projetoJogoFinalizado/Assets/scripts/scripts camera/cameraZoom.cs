using UnityEngine;
using static UnityEngine.GraphicsBuffer;
//Script da Camera

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Camera cam; // Referência à câmera que será controlada
    public float zoomSpeed = 5f; // Velocidade do zoom
    public float minFOV = 50f; // Menor campo de visão permitido (Zoom IN)
    public float maxFOV = 120f; // Maior campo de visão permitido (Zoom OUT)

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // Captura a rolagem do scroll do mouse

        if (scroll != 0) // Se houve movimento no scroll do mouse
        {
            cam.fieldOfView -= scroll * zoomSpeed;
            // Ajusta o FOV (quanto menor o FOV, mais zoom)

            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
            // Garante que o FOV fique dentro dos limites definidos
        }
    }
}