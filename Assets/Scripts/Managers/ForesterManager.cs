using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForesterManager : MonoBehaviour , IValidPosition
{
    //Set by Inspector
    public MeshRenderer myMeshRenderer;
    public Material invalidMaterial;
    private Material originalMaterial;
    void Start()
    {
        originalMaterial = myMeshRenderer.material;
 
        InvokeRepeating("produceWood", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void produceWood() {
        PlayerStatsManagerSystem.increaseWood(1);
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
