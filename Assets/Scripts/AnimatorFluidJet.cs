using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorFluidJet : MonoBehaviour
{
    private const string Pouring = "Pouring";
    private const string Stop = "Stop";

    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private ButtonPouring _buttonPouringEventTrigger;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _shakerLayers.Poured += OnPoured;
        _buttonPouringEventTrigger.Pressed += OnPressed;
        _buttonPouringEventTrigger.Released += OnReleased;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPoured;
        _buttonPouringEventTrigger.Pressed -= OnPressed;
        _buttonPouringEventTrigger.Released -= OnReleased;
    }

    private void OnPressed(Drink arg0)
    {
        _animator.SetTrigger(Pouring);
    }

    private void OnReleased()
    {
        _animator.SetTrigger(Stop);
    }

    private void OnPoured()
    {
        _animator.SetTrigger(Stop);
    }
}
