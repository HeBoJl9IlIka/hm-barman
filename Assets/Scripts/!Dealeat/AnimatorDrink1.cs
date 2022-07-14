//using System.Collections;
//using UnityEngine;

//public class AnimatorDrink : MonoBehaviour
//{
//    private const string DisplaceStrength = "Vector1_3d26797f726f4378b09badd6abe57fb6";
//    private const string Alpha = "Vector1_2e947524c30845e4b1ac4b09b47504d6";

//    [SerializeField] private BottleAnimation _bottleAnimation;
//    [SerializeField] private float _valueDisplace;
//    [SerializeField] private float _valueAlpha;
//    [SerializeField] private float _targetValueDisplace;
//    [SerializeField] private float _divideDisplace;
//    [SerializeField] private float _divideAlpha;
//    [SerializeField] private float _delay;
//    [SerializeField] private float _delayDefault;
//    [SerializeField] private float _correctionPositionBottle;
//    [SerializeField] private float _subtractionValueAlpha;
//    [SerializeField] private float _subtractionValueDisplace;

//    private MeshRenderer _meshRenderer;
//    private float _positionBottle;
//    private bool _isPour;

//    private void Start()
//    {
//        _meshRenderer = GetComponent<MeshRenderer>();
//        _delay = _delayDefault;
//    }

//    private void Update()
//    {
//        if (_isPour == false)
//            return;

//        if (_delay > 0)
//        {
//            _delay -= Time.deltaTime;
//            return;
//        }

//        _valueDisplace = _positionBottle / _divideDisplace;
//        _valueAlpha = _positionBottle / _divideAlpha;

//        SetValueMaterial();
//    }

//    private void OnEnable()
//    {
//        _bottleAnimation.Pouring += OnPouring;
//        _bottleAnimation.Stopped += OnStopped;
//    }

//    private void OnDisable()
//    {
//        _bottleAnimation.Pouring -= OnPouring;
//        _bottleAnimation.Stopped -= OnStopped;
//    }

//    private void OnPouring(float positionBottle)
//    {
//        _isPour = true;
//        _positionBottle = positionBottle - _correctionPositionBottle;
//    }

//    private void OnStopped()
//    {
//        Coroutine coroutine = null;

//        _isPour = false;

//        if (coroutine != null)
//            StopCoroutine(coroutine);

//        coroutine = StartCoroutine(ReturnDefaultState());

//        _delay = _delayDefault;
//    }

//    private void SetValueMaterial()
//    {
//        _meshRenderer.material.SetFloat(Alpha, _valueAlpha);

//        if (_valueDisplace > _targetValueDisplace)
//            return;

//        _meshRenderer.material.SetFloat(DisplaceStrength, _valueDisplace);
//    }

//    private IEnumerator ReturnDefaultState()
//    {
//        while (_valueAlpha >= 0)
//        {
//            _valueDisplace -= _subtractionValueDisplace;
//            _valueAlpha -= _subtractionValueAlpha;

//            SetValueMaterial();

//            yield return null;
//        }
//    }
//}
