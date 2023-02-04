using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIAbilities : MonoBehaviour
{
    VisualElement visualElement;
    Button bFastFire;
    void Awake()
    {
        visualElement = GetComponent<UIDocument>().rootVisualElement;
        bFastFire = visualElement.Q<Button>("BttnFastArrow");
    }
    private void OnEnable()
    {
        Debug.Log("register startAbility");
        visualElement = GetComponent<UIDocument>().rootVisualElement;
        bFastFire = visualElement.Q<Button>("BttnFastArrow");

        bFastFire.clicked += startAbility;
    }
    private void OnDisable()
    {
        Debug.Log("unregister startAbility");
        visualElement = GetComponent<UIDocument>().rootVisualElement;
        bFastFire = visualElement.Q<Button>("BttnFastArrow");

        bFastFire.clicked -= startAbility;
    }
    private void startAbility() {
        Debug.Log("startAbility");
        FastbalistaArrow.StartAbility();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
