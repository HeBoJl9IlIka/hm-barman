using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeightIK : MonoBehaviour
{
    private const float WeightStep = 0.3f;

    [SerializeField] private LaunchingCupState _launchingCupState;
    [SerializeField] private Rig _rig;

    private bool _isMaxWeight => _rig.weight >= 1;

    private void OnEnable()
    {
        _launchingCupState.Launched += OnLaunched;
    }

    private void OnDisable()
    {

        _launchingCupState.Launched += OnLaunched;
    }

    private void OnLaunched()
    {
        StartCoroutine(AddWeight());
    }

    private IEnumerator AddWeight()
    {
        while(_isMaxWeight == false)
        {
            _rig.weight += WeightStep * Time.deltaTime;

            yield return null;
        }
    }
}
