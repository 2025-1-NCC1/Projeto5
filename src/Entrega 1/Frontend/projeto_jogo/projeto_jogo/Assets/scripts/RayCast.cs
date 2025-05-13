using UnityEngine;

public class Raycast : MonoBehaviour
{
    RaycastHit hitInfo;
    GameObject lastHighlighted = null;
    Material originalMaterial;
    public Material highlightMaterial; // <- Coloca um material de destaque no Inspector

    void Update()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            
            if (Physics.Raycast(ray, out hitInfo, 100f))
            {
                GameObject hitObject = hitInfo.collider.gameObject;

                Debug.Log(hitObject.gameObject.name);
                
                // Se mudou de objeto, reseta o anterior
                if (lastHighlighted != null && lastHighlighted != hitObject)
                {
                    lastHighlighted.GetComponent<Renderer>().material = originalMaterial;
                }

            // Salva o material original e aplica o destaque
            if (hitObject.CompareTag("Construcao")) // Certifique-se de marcar os objetos com essa tag
            {
                if (hitObject.gameObject.GetComponent<Predios>())
                {
                    hitObject.gameObject.GetComponent<Predios>().ativo = true;
                    hitObject.gameObject.GetComponent<Predios>().Subir();
                    hitObject.gameObject.GetComponent<Predios>().TrocaMaterial();
                    

                }
            }
            else
            {
                hitObject.gameObject.GetComponent<Predios>().ativo = false;
            }
            }
            


    }
}
