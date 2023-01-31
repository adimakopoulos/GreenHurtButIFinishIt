using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{


    private GameObject EnemyGO;

    void Start()
    {
        EnemyGO = Resources.Load("Prefabs/ZombieGO") as GameObject;
        InvokeRepeating("SpawnPeriodicly", 10f, 3f);
    }


    private void SpawnPeriodicly() {
        GameObject enemy = Instantiate(EnemyGO);
        enemy.transform.position = gameObject.transform.position;
        
    }
}
