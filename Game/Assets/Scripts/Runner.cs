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

    [SerializeField] float positionX = 4;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Keyboard();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Keyboard()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                roadLine--;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                roadLine++;
            }
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
}
