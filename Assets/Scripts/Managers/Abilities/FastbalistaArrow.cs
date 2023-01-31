using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastbalistaArrow : MonoBehaviour
{

    public static event System.Action<float> OnFastArrowStart;
    public static event System.Action OnFastArrowFinish;

    private void OnEnable()
    {
        OnFastArrowStart += stopAfterTime;
    }
    private void OnDisable()
    {
        OnFastArrowStart -= stopAfterTime;
    }
    private void stopAfterTime(float cooldownOfPlayer) {
        Invoke("stopNow", cooldownOfPlayer);
    }
    private void stopNow() {
        OnFastArrowFinish?.Invoke();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            OnFastArrowStart?.Invoke(PlayerStatsManagerSystem.AmmountOfTime);
        }
    }
}
