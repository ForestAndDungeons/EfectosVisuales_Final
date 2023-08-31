using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] float _sensX;
    [SerializeField] float _sensY;

    [SerializeField] Transform _orientation;

    float _rotationX;
    float _rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Get mouse input
        float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensX;
        float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensY;

        _rotationY += _mouseX;
        _rotationX -= _mouseY;

        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        //_rotationY = Mathf.Clamp(_rotationY, -15f, 15f);

        //Rotate cam and orientation
        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        _orientation.rotation = Quaternion.Euler(0, _rotationY, 0);

    }
}
