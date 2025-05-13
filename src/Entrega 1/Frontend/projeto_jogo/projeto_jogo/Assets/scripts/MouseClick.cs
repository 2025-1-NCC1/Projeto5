using UnityEngine;

public class MouseClick : MonoBehaviour
{

    public Vector2 turn;
    public float sensitivity = .5f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }  
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") *  sensitivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        }  
    }
}
