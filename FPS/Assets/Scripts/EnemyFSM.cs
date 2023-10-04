using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFSM : MonoBehaviour
{
    [SerializeField] float sight = 5f;
    [SerializeField] float attackDistance;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Transform target;

    CharacterController cc;

    float currentTime;
    float attackTime = 2f;

    enum State
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die,
    }

    State state;

    private void Start()
    {
        state = State.Idle;
    }

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Return:
                Return();
                break;
            case State.Damaged:
                Damaged();
                break;
            case State.Die:
                Die();
                break;
        }
    }

    public void Idle()
    {
        if (Vector3.Distance(transform.position, target.position) < sight)
        {
            state = State.Move;
        }
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            state = State.Attack;
        }

        Vector3 dir = (target.position - transform.position).normalized;
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }

    public void Attack()
    {
        if (Vector3.Distance(transform.position, target.position) > attackDistance)
        {
            state = State.Move;
            currentTime = 0;
        }

        currentTime += Time.deltaTime;

        if(currentTime > attackTime)
        {
            print("АјАн");
            currentTime = 0;
        }

    }

    public void Return() { }
    public void Damaged() { }
    public void Die() { }


}
