using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIAbilities : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualElement visualElement = GetComponent<UIDocument>().rootVisualElement;

        Button bFastFire = visualElement.Q<Button>("BttnFastArrow");
        bFastFire.clicked += startAbility;


    }
    private void startAbility() {
        FastbalistaArrow.StartAbility();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
