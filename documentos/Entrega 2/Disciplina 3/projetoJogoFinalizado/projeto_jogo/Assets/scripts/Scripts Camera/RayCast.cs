using UnityEngine;

public class Raycast : MonoBehaviour
{
    RaycastHit hitInfo;
    GameObject lastHighlighted = null;
    Material originalMaterial;
    public Material highlightMaterial; // <- Coloca um material de destaque no Inspector
    private Predios predioSelecionado = null;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        GameObject hitObject = null;

        // Raycast para visualização e highlight
        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            hitObject = hitInfo.collider.gameObject;

            Debug.Log(hitObject.name);

            // Se mudou de objeto, reseta o anterior
            if (lastHighlighted != null && lastHighlighted != hitObject)
            {
                lastHighlighted.GetComponent<Renderer>().material = originalMaterial;
            }

            // Salva o material original e aplica o destaque
            if (hitObject.CompareTag("Construcao"))
            {
                if (hitObject.TryGetComponent(out Predios predio))
                {
                    predio.ativo = true;
                    predio.TrocaMaterial();
                }
            }
            else if (hitObject.TryGetComponent(out Predios predio))
            {
                predio.ativo = false;
            }
        }

        // Independente de ter hit ou não — trata clique
        if (Input.GetMouseButtonDown(0))
        {
            if (hitObject != null && hitObject.CompareTag("Construcao"))
            {
                if (hitObject.TryGetComponent(out Predios novoPredio))
                {
                    if (predioSelecionado != null && predioSelecionado != novoPredio)
                    {
                        predioSelecionado.Desselecionar();
                    }

                    novoPredio.Selecionar();
                    predioSelecionado = novoPredio;
                }
            }
            else
            {
                // Clicou em nada ou em algo que não é construção
                if (predioSelecionado != null)
                {
                    predioSelecionado.Desselecionar();
                    predioSelecionado = null;
                }
            }
        }
    }
}
