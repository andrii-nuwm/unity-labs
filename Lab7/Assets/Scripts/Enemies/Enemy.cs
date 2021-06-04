using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private StateType state = StateType.Idle;

    [Header("Movement")]
    [SerializeField] private float idleRotateSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackDistance;
    [Header("Data")]
    private int maxHp;
    [SerializeField] private int hp;

    public DamageEvent OnDamage;

    [System.Serializable]
    public class DamageEvent : UnityEvent<float> {}

    public enum StateType
    {
        Idle,
        Move
    }

    private Dictionary<StateType, Action> stateLogicMap = new Dictionary<StateType, Action>();

    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
        maxHp = hp;

        InitStateLogic();
    }

    private void InitStateLogic()
    {
        stateLogicMap[StateType.Idle] = Idle;
        stateLogicMap[StateType.Move] = Move;
    }

    void Update()
    {
        CheckState();
        stateLogicMap[state]();
    }

    private void CheckState()
    {
        state = Vector3.Distance(transform.position, target.position) < attackDistance ? StateType.Move : StateType.Idle;
    }

    private void Idle()
    {
        transform.Rotate(Vector3.up * idleRotateSpeed * Time.deltaTime);
    }

    private void Move()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public void Damage(int value)
    {
        hp -= value;
        if(hp <= 0)
            Destroy(gameObject);

        OnDamage?.Invoke((float)hp / maxHp);
    }
}
