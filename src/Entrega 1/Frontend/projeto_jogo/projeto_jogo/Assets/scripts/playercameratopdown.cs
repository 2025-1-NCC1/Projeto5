using UnityEngine;

public class PlayerCameraTopDown : MonoBehaviour
{
    public float velocidade = 20.0f;
    Ray RayOrigin;
    RaycastHit HitInfo;
    public Transform cameraTransform; // refer�ncia � c�mera principal

    void Update()
    {
        // Captura os inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Define a dire��o com base na c�mera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Zera o eixo Y (pra manter tudo no plano horizontal)
        forward.y = 0f;
        right.y = 0f;

        // Normaliza os vetores pra evitar velocidade extra nas diagonais
        forward.Normalize();
        right.Normalize();

        // Dire��o final do movimento com base na c�mera
        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        // Move o player/c�mera
        transform.position += moveDirection * velocidade * Time.deltaTime;
    }
}
