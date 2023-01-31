using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{

    public ParticleSystem ParticleSystem;
    public MeshRenderer Renderer;
    public float speed = 1f;
    public int health = 100;

    private Transform AttackLocation;
    void Start()
    {
        AttackLocation = AttackLocationsManager.getRandomAttackPos();
        gameObject.transform.LookAt(AttackLocation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, AttackLocation.transform.position, Time.deltaTime * speed);
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
