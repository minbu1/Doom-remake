using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float mouseSensitivity = 100;
    public Transform Body;
    private float _xRotation = 0;
    private float _yRotation = 0;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _yRotation += mouseX;
        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler( _xRotation, 0, -90);
        transform.localRotation = Quaternion.Euler(0, _yRotation, -90);
        Body.Rotate(Vector3.up * mouseX);
    }
}