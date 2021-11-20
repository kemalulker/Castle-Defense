using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTime = 1f;

    GameObject[] pool;

    void Awake() 
    {   
        pool = new GameObject[poolSize];
        PopulateObjectPool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulateObjectPool()
    {
        

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    
    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            ActivateObjectOnPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void ActivateObjectOnPool()
    {
        foreach (GameObject enemy in pool)
        {
            if(enemy.activeInHierarchy == false) {
                enemy.SetActive(true);
                return;
            }
        }
    }
}
