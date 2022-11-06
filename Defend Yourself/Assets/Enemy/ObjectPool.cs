using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 2f;

    GameObject[] pool;

    void Awake(){
        populatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void populatePool(){
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++){
            int randomNum = Random.Range(0, enemyPrefab.Count);
            pool[i] = Instantiate(enemyPrefab[randomNum], transform);
            pool[i].SetActive(false);
        }
    }

void EnableObjectInPool(){
    for(int i = 0; i < pool.Length; i++){
        if(pool[i].activeInHierarchy == false){
            pool[i].SetActive(true);
            return;
        }
    }
}

    IEnumerator SpawnEnemy(){
        while(true){
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
