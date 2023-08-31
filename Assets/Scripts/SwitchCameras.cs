using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    [SerializeField] Camera _camera1;
    [SerializeField] Camera _camera2;
    [SerializeField] Camera _camera3;
    void Start()
    {
        _camera1.enabled = true;
        _camera2.enabled = false;
        _camera3.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _camera1.enabled = true;
            _camera2.enabled = false;
            _camera3.enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _camera2.enabled = true;
            _camera1.enabled = false;
            _camera3.enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            _camera3.enabled = true;
            _camera1.enabled = false;
            _camera2.enabled = false;
        }
    }
}
