using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] GameObject[] prefab;
    [SerializeField] Transform[] transforms;
    
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    public void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject clone = Instantiate(prefab[Random.Range(0, prefab.Length)], transform);

            clone.SetActive(false);

            obstacles.Add(clone);
        }
    }
}