using UnityEngine;
//Script da Camera
public class MouseClick : MonoBehaviour
{

    public Vector2 turn;// declaração da variável turn com um vetor 2D (x e y)
    public float sensitivity = .5f; // sensibilidade do mouse
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // comando para o cursor não aparecer na tela durante o jogo
    }  
    void Update()
    {   // movimentação do mouse ao pressionar o botão direito
        if (Input.GetMouseButton(1))
        {       
            turn.x += Input.GetAxis("Mouse X") * sensitivity; // Multiplicação da sensibilidade do mouse pelo movimento no eixo X
            turn.y += Input.GetAxis("Mouse Y") * sensitivity; // Multiplicação da sensibilidade do mouse pelo movimento no eixo Y
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0); // comando para realizar a rotação de um objeto convertendo valores de um ângulo
            

        }
    }
}
