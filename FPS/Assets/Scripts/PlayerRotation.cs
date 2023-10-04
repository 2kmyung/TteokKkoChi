using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    float mx;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(0, mouseX, 0);

        mx += mouseX * rotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
