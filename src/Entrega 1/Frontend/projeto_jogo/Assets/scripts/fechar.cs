using UnityEngine;

public class fechar : MonoBehaviour
{
    public GameObject menuPanel;
    public Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FecharMenu()
    {
        if (cam.GetComponent<Raycast>().mouseAtivo == true)
        {
            cam.GetComponent<Raycast>().mouseAtivo = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        menuPanel.SetActive(false);
    }
}
