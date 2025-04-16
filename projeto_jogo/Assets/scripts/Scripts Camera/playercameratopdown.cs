using UnityEngine;

public class PlayerCameraTopDown : MonoBehaviour
{
    public float velocidade = 20.0f;
    public float velocidadeCorrendo = 40.0f; // velocidade quando est� com o Control pressionado
    public Transform cameraTransform; // refer�ncia � c�mera principal

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        float velocidadeAtual = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)
            ? velocidadeCorrendo
            : velocidade;

        transform.position += moveDirection * velocidadeAtual * Time.deltaTime;
    }
}
