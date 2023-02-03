using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTowerManager : MonoBehaviour
{
    private GameObject ArrowGO;
    public Transform ArroPointOut;
    private int arrowsPerShot = 1;

    private void OnEnable()
    {
        FastbalistaArrow.OnFastArrowStart += setNewFiringCoolDown;
        FastbalistaArrow.OnFastArrowFinish += setOriginalCoolDown;
    }

    private void OnDisable()
    {
        FastbalistaArrow.OnFastArrowStart -= setNewFiringCoolDown;
        FastbalistaArrow.OnFastArrowFinish -= setOriginalCoolDown;
    }
    // Start is called before the first frame update
    void Start()
    {
        ArrowGO = Resources.Load("Prefabs/BallistaArrow") as GameObject;
        originalValueCoolDown = 1.7f;
    }

    float currentCoolDown = 1.7f;
    float originalValueCoolDown = 1.7f;
    float timeElasped = 99f;
    void Update()
    {
        if (validateFireLocation())
        {
            fireArrow();
        }

    }

    private void setOriginalCoolDown()
    {
        currentCoolDown = originalValueCoolDown;
    }
    private void setNewFiringCoolDown() {
        currentCoolDown *= 0.3f;
        timeElasped = 66f;//force reset  
    }
    private void fireArrow()
    {
        if (Input.GetMouseButton(0) && timeElasped > currentCoolDown && PlayerStatsManagerSystem.BalistaArrows >= arrowsPerShot)
        {
            PlayerStatsManagerSystem.BalistaArrows -= arrowsPerShot;
            timeElasped = 0f;
            createAndSetArrow();
        }
        else
        {
            timeElasped += Time.deltaTime;
        }
    }

    private bool validateFireLocation()
    {
        return UserInputManagerSystem.getWorldPosition().x > 20;
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
