using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    float mx = 0, my = 0;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 dir = new Vector3(-mouseY, mouseX, 0);

        mx += mouseX * rotationSpeed * Time.deltaTime;
        my += mouseY * rotationSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
