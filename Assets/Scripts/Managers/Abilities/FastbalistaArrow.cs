using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastbalistaArrow : MonoBehaviour
{

    public static event System.Action OnFastArrowStart;
    public static event System.Action OnFastArrowFinish;

    static bool isActive = false;
    public static void StartAbility() {
        OnFastArrowStart?.Invoke();
        isActive = true;
        Debug.Log("StartAbility");

    }

    private float timeElasped=0f;
    private void Update()
    {
        if (isActive) {
            timeElasped+= Time.deltaTime;
        }
        if (timeElasped > PlayerStatsManagerSystem.AmmountOfTime) {
            timeElasped = 0f;
            stopNow();
        }
    }
    private void stopNow() {
        Debug.Log("stopNow");
        isActive = false;
        OnFastArrowFinish?.Invoke();
    }

}
