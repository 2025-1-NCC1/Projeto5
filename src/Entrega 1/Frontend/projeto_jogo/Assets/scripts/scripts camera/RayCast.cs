using UnityEditor;
using UnityEngine;

// Script da Camera
public class Raycast : MonoBehaviour
{

    public Canvas MenuUI;

    RaycastHit hitInfo;
    GameObject lastHighlighted = null;
    Material originalMaterial;
    public Material highlightMaterial; // <- Coloca um material de destaque no Inspector
    private Predios predioSelecionado = null;
    public bool mouseAtivo = false;
    void Update()
    {


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


        // Raycast para visualização e highlight
        if (Physics.Raycast(ray, out hitInfo, 1000f))
        {


            if (Input.GetMouseButtonDown(0))
            {

                Debug.Log("Oi");
                if (hitInfo.collider.gameObject.CompareTag("Construcao") || hitInfo.collider.gameObject.CompareTag("casas"))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out Predios novoPredio))
                    {
                        // Deseleciona anterior, se necessário
                        if (predioSelecionado != null && predioSelecionado != novoPredio)
                        {
                            predioSelecionado.Desselecionar();
                        }

                        // Seleciona novo
                        novoPredio.Selecionar();
                        predioSelecionado = novoPredio;


                        if (hitInfo.collider.gameObject.GetComponent<CasaBehaviour>())
                        {
                            // string tipos = string.Join(",", casa.tiposDeConsumo);
                            if (mouseAtivo == false)
                            {
                                mouseAtivo = true;
                                Cursor.lockState = CursorLockMode.None;
                            }

                            MenuUI.GetComponent<MenuUi>().MostrarInformacoes(hitInfo.collider.gameObject.GetComponent<CasaBehaviour>());
                            Debug.Log("$" + hitInfo.collider.gameObject.name + "Moradores:" /*{casa.moradores}, Tipos: [{tipos}], Água: {casa.consumoAguaTotal}L/dia, Energia: {casa.consumoEnergiaTotal}kWh/dia"*/);

                        }
                    }
                }

            }
            // Se mudou de objeto, reseta o anterior
            if (lastHighlighted != null && lastHighlighted != hitInfo.collider.gameObject)
            {
                lastHighlighted.GetComponent<Renderer>().material = originalMaterial;
            }

            // Salva o material original e aplica o destaque
            if (hitInfo.collider.gameObject.CompareTag("Construcao") || hitInfo.collider.gameObject.CompareTag("casas"))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Predios predio))
                {
                    predio.ativo = true;
                    predio.TrocaMaterial();
                }
            }
            else if (hitInfo.collider.gameObject.TryGetComponent(out Predios predio))
            {
                predio.ativo = false;
            }
        }



    }
}
