using UnityEngine;

public class PlacementSystem : MonoBehaviour
{

    [SerializeField]
    private GameObject mouseIndicator;
    [SerializeField]
    private InputManager inputManager;

    private void Update()
    {
        Vector3 mouseposition = inputManager.GetSelectedMapPosition();
        mouseIndicator.transform.position = mouseposition;
    }

}
