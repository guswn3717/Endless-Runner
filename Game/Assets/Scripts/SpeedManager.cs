using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;

    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }

    public float InitializeSpeed { get { return initializeSpeed; } }   

    private void OnEnable()
    {
        initializeSpeed = speed;

        SceneManager.sceneLoaded += OnSceneLoaded;

        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    }

    private void Execute()
    {
        StartCoroutine(Increase());
    }

    private void Release()
    {
        StopAllCoroutines();
    }

    IEnumerator Increase()
    {
        while(speed < limitSpeed)
        {
            yield return CoroutineCache.WaitForSecond(0.533f);

            speed = speed + 0.5f;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        speed = 30;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);
    }
}
