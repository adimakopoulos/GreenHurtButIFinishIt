using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour , IEnemy
{

    public ParticleSystem ParticleSystem;
    public MeshRenderer Renderer;
    public float speed = 1f;
    public int health = 100;
    public int DamageToPlayer = 10;

    private Action OnReachedLastTile;
    private GameObject AttackLocation;
    private int currentTargetIndex = 0;
    private void OnEnable()
    {
        OnReachedLastTile += doDamage;
    }
    private void OnDisable()
    {
        OnReachedLastTile -= doDamage;
    }
    void Start()
    {
        setInitialLocationToWalk();
    }

    void Update()
    {
        if (transform.position != AttackLocation.transform.position + new Vector3(0.5f, 0.3f, 0.5f))
        {
            transform.position = Vector3.MoveTowards(transform.position, AttackLocation.transform.position + new Vector3(0.5f, 0.3f, 0.5f), Time.deltaTime * speed);
        }
        else {
            if (currentTargetIndex < RoadManagerSystem.allRoadTiles.Count-1)
            {
                changeTargetToReach();
            }
        }

    }

    
    public void doDamage()
    {
        PlayerStatsManagerSystem.Health -= DamageToPlayer;
        gameObject.SetActive(false);
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        ParticleSystem.Play();
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void setInitialLocationToWalk()
    {
        AttackLocation = RoadManagerSystem.allRoadTiles[0];
        gameObject.transform.LookAt(AttackLocation.transform);
    }
    private void changeTargetToReach()
    {
        currentTargetIndex++;
        AttackLocation = RoadManagerSystem.allRoadTiles[currentTargetIndex];
        gameObject.transform.LookAt(AttackLocation.transform.position + new Vector3(0.5f, 0.3f, 0.5f));
        if (currentTargetIndex >= RoadManagerSystem.allRoadTiles.Count - 1)
        {
            OnReachedLastTile?.Invoke();
        }
    }



}
