using UnityEngine;
//Script da Camera
public class MouseClick : MonoBehaviour
{

    public Vector2 turn;// declara��o da vari�vel turn com um vetor 2D (x e y)
    public float sensitivity = .5f; // sensibilidade do mouse
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // comando para o cursor n�o aparecer na tela durante o jogo
    }  
    void Update()
    {   // movimenta��o do mouse ao pressionar o bot�o direito
        if (Input.GetMouseButton(1))
        {       
            turn.x += Input.GetAxis("Mouse X") * sensitivity; // Multiplica��o da sensibilidade do mouse pelo movimento no eixo X
            turn.y += Input.GetAxis("Mouse Y") * sensitivity; // Multiplica��o da sensibilidade do mouse pelo movimento no eixo Y
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0); // comando para realizar a rota��o de um objeto convertendo valores de um �ngulo
            

        }
    }
}
