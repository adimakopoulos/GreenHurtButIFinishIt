using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour, IValidPosition
{
    //Set by Inspector
    public MeshRenderer myMeshRenderer;
    public Material invalidMaterial;
    private Material originalMaterial;
    void Start()
    {
        originalMaterial = myMeshRenderer.material;
        InvokeRepeating("produceFood", 0, 5);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void produceFood()
    {
        PlayerStatsManagerSystem.increaseFood(1);
    }

    public void SetMaterialIfInvalid(bool isValid)
    {
        if (isValid)
        {
            myMeshRenderer.material = originalMaterial;

        }
        else
        {
            myMeshRenderer.material = invalidMaterial;
        }
    }
}
