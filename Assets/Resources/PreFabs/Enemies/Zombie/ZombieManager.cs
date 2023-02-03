using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{

    public ParticleSystem ParticleSystem;
    public MeshRenderer Renderer;
    public float speed = 1f;
    public int health = 100;

   
    private GameObject AttackLocation;
    void Start()
    {
        AttackLocation = RoadManagerSystem.allRoadTiles[0];
        gameObject.transform.LookAt(AttackLocation.transform);
    }
    
    private int currentTargetIndex  = 0 ;
    // Update is called once per frame
    void Update()
    {
        if (transform.position != AttackLocation.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, AttackLocation.transform.position, Time.deltaTime * speed);
        }
        else {
            if (currentTargetIndex < RoadManagerSystem.allRoadTiles.Count) {
                currentTargetIndex++;
                AttackLocation = RoadManagerSystem.allRoadTiles[currentTargetIndex];
            }
        }

    }

    public void takeDamage()
    {
        health -= PlayerStatsManagerSystem.PAttack;
        ParticleSystem.Play();
        if (health <= 0) { 
            gameObject.SetActive(false);
        }
    }
}
