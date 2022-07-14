using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections;

public class MixedState : State
{
    [SerializeField] private Shaker _shaker;
    [SerializeField] private Transform _defaultPosition;
    [SerializeField] private Vector3[] _path;
    [SerializeField] private Vector3 _defaultRotation;
    [SerializeField] private Quaternion _minRotation;
    [SerializeField] private Quaternion _maxRotation;
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _mixingTime;
    [SerializeField] private float _targetMixingTime;
    [SerializeField] private float _delayReportReadiness;
    [SerializeField] private float _duration;

    //[SerializeField] private Transform _minPosition;
    //[SerializeField] private Transform _maxPosition;
    //[SerializeField] private Transform _lastPosition;
    //[SerializeField] private float _correction;


    //private Camera _camera;
    private Tween _tween;
    private bool _isMixing;

    private bool _isMixed => _mixingTime >= _targetMixingTime;

    public bool IsMixed { get; private set; }
    public float MixingTime => _mixingTime;

    [SerializeField] private UnityEvent _mixed;

    public event UnityAction Mixed;
    public event UnityAction Moving;
    public event UnityAction Stopped;

    private void Start()
    {
        //_shaker.transform.position = _defaultPosition.position;
        _speed = _defaultSpeed;
    }

    public void Mix()
    {
        _isMixing = true;
        _speed = _defaultSpeed;

        _tween = _shaker.transform.DOPath(_path, _speed, PathType.CatmullRom).SetOptions(true);
        _tween.SetEase(Ease.Linear).SetLoops(-1);
    }

    public void Stop()
    {
        _isMixing = false;
        _speed = 0;

        _tween = _shaker.transform.DOPath(_path, _speed, PathType.CatmullRom).SetOptions(true);
        _tween.SetEase(Ease.Linear).SetLoops(-1);

        Stopped?.Invoke();
    }

    private void Update()
    {
        
        if (_isMixing)
        {
            _shaker.transform.rotation = Quaternion.Lerp(_minRotation, _maxRotation, _shaker.transform.position.x);
            _mixingTime += Time.deltaTime;
            Moving?.Invoke();
            //if (Input.GetMouseButton(0))
            //{
            //    //_mixingTime += Time.deltaTime;
            //    Tween tween = _shaker.transform.DOPath(_path, 5, PathType.CatmullRom).SetOptions(true).SetLookAt(0.01f);
            //    Moving?.Invoke();
            //}
            //else
            //{
            //    Stopped?.Invoke();
            //}
            //Vector3 positionMouse = new Vector3();
            //positionMouse = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane));

            //_shaker.transform.position = Vector3.Lerp(_minPosition.position, _maxPosition.position, positionMouse.y + _correction);
            //

            //if (_shaker.transform.position != _lastPosition.position)
            //{

            //    _lastPosition.position = _shaker.transform.position;

            //}
            //else
            //{

            //}
        }

        if (_isMixed)
        {
            _shaker.transform.DOMove(_defaultPosition.position, _duration);
            _shaker.transform.DORotate(_defaultRotation, _duration);
            
            Invoke(nameof(ReportReadiness), _delayReportReadiness);
        }
    }

    public void ReportReadiness()
    {
        _mixed?.Invoke();
        Mixed?.Invoke();
        IsMixed = true;
    }
}
