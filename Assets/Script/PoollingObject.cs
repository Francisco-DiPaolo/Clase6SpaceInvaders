using System.Collections.Generic;
using UnityEngine;

public class PoollingObject : MonoBehaviour
{
    public static PoollingObject Instance { get; private set; }

    public List<GameObject> pooledObjects;
    public int amountToPool;

    GameObject projectile;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        InstanciateProyectiles();
    }

    void InstanciateProyectiles()
    {
        GameObject projectile = Resources.Load<GameObject>("Prefabs/Projectile");

        pooledObjects = new List<GameObject>();
        GameObject objectInScene;
        for (int i = 0; i < amountToPool; i++)
        {
            objectInScene = Instantiate(projectile);
            objectInScene.SetActive(false);
            pooledObjects.Add(objectInScene);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}