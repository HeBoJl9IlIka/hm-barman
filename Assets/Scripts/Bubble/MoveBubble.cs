using UnityEngine;

public class MoveBubble : MonoBehaviour
{
    [SerializeField] private ShakerLayers _shakerLayers;

    private void OnEnable()
    {
        _shakerLayers.Pouring += OnPouring;
    }

    private void OnDisable()
    {
        _shakerLayers.Pouring -= OnPouring;
    }

    private void OnPouring()
    {
        transform.position = new Vector3(transform.position.x, _shakerLayers.CurrentPositionDrink, transform.position.z);
    }
}
