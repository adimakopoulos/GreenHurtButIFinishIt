using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrowManager : MonoBehaviour
{

    public Vector3 targetToReach;
    public float speed;
    private void OnEnable()
    {
        Invoke("killArrow", 10f);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetToReach != Vector3.zero)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, targetToReach, Time.deltaTime * speed);
        }
        if (gameObject.transform.position.y <= 0.1f)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("killArrow", 5f);
        }
    }
    private void killArrow() {
        gameObject.SetActive(false);
    }
    public void SetTarget(Vector3 target)
    {
        targetToReach = target;
    }
    private void OnTriggerEnter(Collider other)
    {
        doDamageOnCollision(other);
    }

    private static void doDamageOnCollision(Collider other)
    {
        if (other != null)
        {
            var zombieManager = other.gameObject.GetComponent<ZombieManager>();
            if (zombieManager != null)
            {
                zombieManager.takeDamage();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
