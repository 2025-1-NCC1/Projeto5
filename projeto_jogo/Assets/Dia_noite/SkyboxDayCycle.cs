using UnityEngine;

public class SkyboxDayCycle : MonoBehaviour
{
    [Header("Duração do ciclo (em segundos)")]
    public float fullDayLength = 180f;

    private Material skyboxMat;
    private float currentTime = 0f;

    void Start()
    {
        skyboxMat = RenderSettings.skybox;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        float t = (currentTime % fullDayLength) / fullDayLength;

        float blend;

        if (t < 0.4f)
        {
            // DIA
            blend = 0f;
        }
        else if (t < 0.5f)
        {
            // ENTARDECER (10%)
            float p = (t - 0.4f) / 0.1f;
            blend = Mathf.Lerp(0f, 1f, p);
        }
        else if (t < 0.9f)
        {
            // NOITE (40%)
            blend = 1f;
        }
        else
        {
            // AMANHECER (10%)
            float p = (t - 0.9f) / 0.1f;
            blend = Mathf.Lerp(1f, 0f, p);
        }

        skyboxMat.SetFloat("_Blend", blend);
        DynamicGI.UpdateEnvironment();
    }
}
