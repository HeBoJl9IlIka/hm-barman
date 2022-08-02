using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private ShakerLayers _shakerLayers;

    private void OnEnable()
    {
        _shakerLayers.Poured += OnPoured;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPoured;
    }

    private void OnPoured()
    {
        gameObject.SetActive(false);
    }
}