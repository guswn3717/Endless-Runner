using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    static SpeedManager instance;

    [SerializeField] float speed = 30.0f;

    public float Speed { get { return speed; } }

    public static SpeedManager Instance { get { return instance; } }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
