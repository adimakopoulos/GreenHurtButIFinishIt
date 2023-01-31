using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTowerManager : MonoBehaviour
{
    private GameObject ArrowGO;
    public Transform ArroPointOut;
    // Start is called before the first frame update
    void Start()
    {
        ArrowGO = Resources.Load("Prefabs/BallistaArrow") as GameObject;
    }

    float coolDown = 1.7f;
    float timeElasped = 0f;
    void Update()
    {

        if (Input.GetMouseButton(0) && timeElasped > coolDown)
        {
            timeElasped = 0f;
            createAndSetArrow();
        }
        else {
            timeElasped += Time.deltaTime;
        }

    }

    private void createAndSetArrow()
    {
        Vector3 clickedWorldPos = UserInputManagerSystem.getWorldPosition();
        var arrowClone = Instantiate(ArrowGO);
        arrowClone.transform.position = ArroPointOut.position;
        arrowClone.transform.LookAt(clickedWorldPos);
        arrowClone.GetComponent<BallistaArrowManager>().SetTarget(clickedWorldPos);
    }
}
