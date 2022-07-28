using UnityEngine;

public class MoveBubble : MonoBehaviour
{
    [SerializeField] private ShakerFillingState _shakerFillingState;
    [SerializeField] private ShakerLayers _shakerLayers;

    private void OnEnable()
    {
        _shakerFillingState.Pouring += OnPouring;
    }

    private void OnDisable()
    {
        _shakerFillingState.Pouring -= OnPouring;
    }

    private void OnPouring()
    {
        transform.position = new Vector3(transform.position.x, _shakerLayers.CurrentPositionDrink, transform.position.z);
    }
}
