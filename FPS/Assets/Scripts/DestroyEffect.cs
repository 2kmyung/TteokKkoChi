using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] float destroyTime = 1.5f;
    float currentTIme = 0;

    void Update()
    {
        if(currentTIme > destroyTime)
        {
            Destroy(gameObject);
        }

        currentTIme += Time.deltaTime;
    }
}
