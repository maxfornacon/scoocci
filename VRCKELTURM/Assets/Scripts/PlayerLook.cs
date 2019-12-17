﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] public string mouseXInputName, mouseYInputName;
    [SerializeField] public float mouseSensitivity;
    
    [SerializeField] public Transform playerBody;
    
    private float xAxisClamp;

    private void Awake()
    {
        xAxisClamp = 0.0f;
    }

    private void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;
        
            xAxisClamp+=mouseY;

            if(xAxisClamp>90.0f)
            {
                xAxisClamp=90.0f;
                mouseY=0.0f;
                ClampXAxisRotationToValue(270.0f);
            }
            else if(xAxisClamp<-90.0f)
            {
                xAxisClamp=-90.0f;
                mouseY=0.0f;
                ClampXAxisRotationToValue(90.0f);
            }

            transform.Rotate(Vector3.left * mouseY);
            playerBody.Rotate(Vector3.up*mouseX);
        }
    }

    private void ClampXAxisRotationToValue (float value){
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;

    }
}
