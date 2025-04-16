using UnityEngine;

public class Dia_e_Noite : MonoBehaviour
{
    [Range(0, 1)]
    public float blend = 0f;
    public float transitionSpeed = 0.1f; // velocidade de transição

    private Material skyboxMat;

    void Start()
    {
        skyboxMat = RenderSettings.skybox;
    }

    void Update()
    {
        // Exemplo: usar T para ativar transição
        if (Input.GetKey(KeyCode.T))
        {
            blend += Time.deltaTime * transitionSpeed;
        }
        else
        {
            blend -= Time.deltaTime * transitionSpeed;
        }

        blend = Mathf.Clamp01(blend);
        skyboxMat.SetFloat("_Blend", blend);
        DynamicGI.UpdateEnvironment(); // Atualiza a iluminação global
    }
}