using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AnimatorBubble : MonoBehaviour
{
    [SerializeField] private ContainerFillingState _containerFillingState;

    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }

    private void OnEnable()
    {
        _containerFillingState.Pouring += OnPouring;
        _containerFillingState.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _containerFillingState.Pouring -= OnPouring;
        _containerFillingState.Stopped -= OnStopped;
    }

    private void OnPouring()
    {
        _particleSystem.Play();
    }

    private void OnStopped()
    {
        _particleSystem.Stop();
    }
}
