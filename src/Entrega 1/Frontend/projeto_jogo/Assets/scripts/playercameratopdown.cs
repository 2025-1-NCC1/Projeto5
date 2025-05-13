using UnityEngine;
//Script do player

public class PlayerCameraTopDown : MonoBehaviour
{
    public float velocidadeNormal = 20.0f;
    public float velocidadeCorrendo = 40.0f;

    Ray RayOrigin;
    RaycastHit HitInfo;
    public Transform cameraTransform; // referência à câmera principal

    // Limites do mapa
    public float limiteMinX = -8f;
    public float limiteMaxX = 251f;
    public float limiteMinZ = -8f;
    public float limiteMaxZ = 226f;

    void Update()
    {
        // Captura os inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Define a direção com base na câmera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Zera o eixo Y (pra manter tudo no plano horizontal)
        forward.y = 0f;
        right.y = 0f;

        // Normaliza os vetores pra evitar velocidade extra nas diagonais
        forward.Normalize();
        right.Normalize();

        // Direção final do movimento com base na câmera
        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        float velocidadeAtual = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightControl) ? velocidadeCorrendo : velocidadeNormal;

        // Calcula nova posição
        Vector3 novaPosicao = transform.position + moveDirection * velocidadeAtual * Time.deltaTime;

        // Aplica os limites no eixo X e Z
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteMinX, limiteMaxX);
        novaPosicao.z = Mathf.Clamp(novaPosicao.z, limiteMinZ, limiteMaxZ);

        // Aplica o movimento limitado
        transform.position = novaPosicao;
    }
}
