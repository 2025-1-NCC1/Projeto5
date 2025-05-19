using Unity.VisualScripting;
using UnityEngine;

//Script da Camera
//O target é o game object player
public class CameraTopDown : MonoBehaviour
{
    //declarei a variavel que controla a velocidade da camera
    public float velocidade = 5.0f;
    // acessa o objeto que a camera precisa seguir
    public Transform target;
    // distancia dos eixos entre a camera e o player
    public Vector3 offset = Vector3.up;

    Ray RayOrigin;
    RaycastHit HitInfo;


    void Update()
    {   //faz a movimentação de forma suave
        transform.position = Vector3.Lerp(transform.position, target.position + offset, velocidade * Time.deltaTime);
               
    }
}
