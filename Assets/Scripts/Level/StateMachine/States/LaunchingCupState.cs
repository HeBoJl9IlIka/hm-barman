using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingCupState : State
{
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private float _speed;
    [SerializeField] private float _delayReportReadiness;

    private Transform _cup;
    private Rigidbody _rigidbody;
    private Camera _camera;
    private Vector3 _firstPosition;
    private Vector3 _endPosition;
    private float _direction;


    public bool IsLaunched { get; private set; }

    private void OnEnable()
    {
        _cup = _selectingCupState.Cup.transform;
        _rigidbody = _selectingCupState.Cup.GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane));
        }

        if (Input.GetMouseButtonUp(0))
        {
            _endPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane));
            _direction = _endPosition.x - _firstPosition.x;
            _cup.rotation = new Quaternion(_cup.rotation.x, _direction, _cup.rotation.z, _cup.rotation.w);
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = _cup.forward * _speed;

            Invoke(nameof(ReportReadiness), _delayReportReadiness);
        }
    }

    private void ReportReadiness()
    {
        IsLaunched = true;
    }
}
