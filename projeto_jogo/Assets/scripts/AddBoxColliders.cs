using UnityEngine;

public class AddBoxCollidersByTag : MonoBehaviour
{
    public string tagName = "coliderTag"; // Defina essa tag no Inspector ou direto no código

    void Start()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagName);

        foreach (GameObject obj in taggedObjects)
        {
            if (obj.GetComponent<BoxCollider>() == null)
            {
                obj.AddComponent<BoxCollider>();
            }
        }

        Debug.Log("Box Colliders adicionados aos objetos com a tag: " + tagName);
    }
}
