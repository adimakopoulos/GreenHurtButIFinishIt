using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarryManager : MonoBehaviour , IValidPosition
{
    public GameObject WorkStation1, WorkStation2, WorkStation3, WorkStation4;
    //Set by Inspector
    public MeshRenderer myMeshRenderer;
    public Material invalidMaterial;
    private Material originalMaterial;
    void Start()
    {
        originalMaterial = myMeshRenderer.material;
        InvokeRepeating("produceStone", 0, 5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void produceStone()
    {
        PlayerStatsManagerSystem.increaseStone(1);
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
