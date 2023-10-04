using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    CharacterController cc;

    float gravity = -10f;
    float yVelocity = 0;
    bool isJumping = false;
    [SerializeField] float jumpPower = 10f;
    

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 입력
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        // 수평 이동 관련 값 설정
        Vector3 dir = new Vector3 (h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);

        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }

        // 수직 이동 관련 값 설정
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 이동
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
