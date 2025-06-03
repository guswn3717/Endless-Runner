using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, Collidable
{
    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Release);
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(Vector3.up * SpeedManager.Instance.Speed * Time.deltaTime);
    }

    void Release()
    {
        Destroy(this);
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Release);
    }
}
