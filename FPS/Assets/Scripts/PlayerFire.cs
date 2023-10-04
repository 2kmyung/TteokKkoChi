using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject firePosition;

    [SerializeField] GameObject bombFactory;

    [SerializeField] GameObject bulletEffect;

    [SerializeField] public float throwPower = 15f;

    ParticleSystem ps;

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, Camera.main.transform.forward);
            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray, out hit))
            {
                bulletEffect.transform.position = hit.point;
                bulletEffect.transform.forward = hit.normal;
                ps.Play();
            }
        }
    }
}
