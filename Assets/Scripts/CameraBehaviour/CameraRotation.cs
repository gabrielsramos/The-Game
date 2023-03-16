using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private InputAction mouseInputAction;
    [SerializeField] private float rotationVelocity = 200;

    private CinemachineFreeLook freeLookCamera;

    private void Start()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    private void OnEnable()
    {
        mouseInputAction.Enable();
        mouseInputAction.started += StartRotation;
        mouseInputAction.canceled += FinishRotation;
    }

    private void OnDisable()
    {
        mouseInputAction.started -= StartRotation;
        mouseInputAction.canceled -= FinishRotation;
        mouseInputAction.Disable();
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            freeLookCamera.m_YAxis.m_MaxSpeed = 10;
        }
    }

    private void StartRotation(InputAction.CallbackContext context)
    {
        freeLookCamera.m_XAxis.m_MaxSpeed = rotationVelocity;
    }

    private void FinishRotation(InputAction.CallbackContext context)
    {
        freeLookCamera.m_XAxis.m_MaxSpeed = 0;
    }
}
