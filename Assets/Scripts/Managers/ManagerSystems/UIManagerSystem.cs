using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManagerSystem : MonoBehaviour
{
    public GameObject UIBuildings;
    public GameObject UITowerAbilities;
    public GameObject Camera;

    private Action onCameraChangePosition; 

    // Start is called before the first frame update
    void Start()
    {
        showBuildingsMenu();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Camera.transform.position.x > 25 && !UITowerAbilities.activeInHierarchy)//&& !UIBuildings.enabled
        {
            showAbilitiesTowerMenu();
        }


        if(Camera.transform.position.x <= 25 && !UIBuildings.activeInHierarchy)//&& !UITowerAbilities.enabled
        {
            showBuildingsMenu();
        }
    }

    private void showAbilitiesTowerMenu()
    {
        UIBuildings.gameObject.SetActive(false);
        UITowerAbilities.gameObject.SetActive(true);
    }

    private void showBuildingsMenu()
    {
        UIBuildings.gameObject.SetActive(true);
        UITowerAbilities.gameObject.SetActive(false);
    }
}
