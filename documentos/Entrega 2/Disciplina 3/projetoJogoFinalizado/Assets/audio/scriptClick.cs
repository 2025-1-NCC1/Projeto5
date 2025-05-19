using UnityEngine;

public class MouseClickSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = bot�o esquerdo do mouse
        {
            audioSource.Play();
        }
    }
}
