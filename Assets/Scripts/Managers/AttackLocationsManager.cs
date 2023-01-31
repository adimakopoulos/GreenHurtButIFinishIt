using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackLocationsManager : MonoBehaviour
{
    public static List<Transform> AttackLocationsTransforms = new List<Transform>();
    // Start is called before the first frame update
    private void Awake()
    {
        AttackLocationsTransforms = GetComponentsInChildren<Transform>().ToList();
    }

    public static Transform getRandomAttackPos() { 
        int randomIndex = Random.Range(1, AttackLocationsTransforms.Count);
        return AttackLocationsTransforms[randomIndex];
    }


}
