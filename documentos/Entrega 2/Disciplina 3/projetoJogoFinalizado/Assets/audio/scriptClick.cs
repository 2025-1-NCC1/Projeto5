using UnityEngine;

public class MouseClickSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = botão esquerdo do mouse
        {
            audioSource.Play();
        }
    }
}
