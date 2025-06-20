using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT   = -1,
    MIDDLE = 0,
    RIGHT  = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] Animator animator;
    [SerializeField] float positionX = 4;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Die);
        State.Subscribe(Condition.FINISH, Release);

        State.Subscribe(Condition.START, InputSystem);
        State.Subscribe(Condition.START, StateTransition);
    }

    public void InputSystem()
    {
        StartCoroutine(Coroutine());
    }

    void Release()
    {
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        Move();
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (roadLine != RoadLine.LEFT)
                {
                    roadLine--;

                    animator.Play("Left Avoid");
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (roadLine != RoadLine.RIGHT)
                {
                    roadLine++;

                    animator.Play("Right Avoid");
                }
            }

            yield return null;
        }
    }

    void Move()
    {
        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position,
            new Vector3(positionX * (int)roadLine, 0, 0),
            SpeedManager.Instance.Speed * Time.deltaTime
        );
    }

    void Die()
    {
        animator.Play("Die");
    }

    public void StateTransition()
    {
        animator.SetTrigger("Start");
    }

    public void Synchronize()
    {
        animator.speed = SpeedManager.Instance.Speed / SpeedManager.Instance.InitializeSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if(obstacle != null)
        {
            State.Publish(Condition.FINISH);
        }
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Die);
        State.Unsubscribe(Condition.FINISH, Release);

        State.Unsubscribe(Condition.START, InputSystem);
        State.Unsubscribe(Condition.START, StateTransition);
    }
}
