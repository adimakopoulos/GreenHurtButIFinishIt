using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UI : MonoBehaviour
{
    Button bQuary;
    Button bForester;
    Button bFarm;
    private void Awake()
    {
        VisualElement visualElement = GetComponent<UIDocument>().rootVisualElement;

        bQuary = visualElement.Q<Button>("BttnQuary");
        bForester = visualElement.Q<Button>("BttnForester");
        bFarm = visualElement.Q<Button>("BttnFarm");
    }
    private void OnEnable()
    {
        VisualElement visualElement = GetComponent<UIDocument>().rootVisualElement;

        bQuary = visualElement.Q<Button>("BttnQuary");
        bForester = visualElement.Q<Button>("BttnForester");
        bFarm = visualElement.Q<Button>("BttnFarm");

        Label txtStats = visualElement.Q<Label>("TxtStats");
        Label tQuary = visualElement.Q<Label>("TxtQuary");
        Label tForester = visualElement.Q<Label>("TxtForester");
        Label tFarm = visualElement.Q<Label>("TxtFarm");

        bQuary.clicked += PlayerBuildsManagerSystem.setWantedBuildingQuarry;
        bForester.clicked += PlayerBuildsManagerSystem.setWantedBuildingForester;
        bFarm.clicked += PlayerBuildsManagerSystem.setWantedBuildingFarm;

        PlayerStatsManagerSystem.OnVariablesChanged += updateValues;
        tFarm.text = "Cost wood:" + BuildingStore.FarmWoodCost;
        tQuary.text = "Cost wood:" + BuildingStore.QuaryWoodCost + ", stone: " + BuildingStore.QuaryStoneCost;
        tForester.text = "Cost wood:" + BuildingStore.ForesterWoodCost;
    }
    private void OnDisable()
    {
        bQuary.clicked -= PlayerBuildsManagerSystem.setWantedBuildingQuarry;
        bForester.clicked -= PlayerBuildsManagerSystem.setWantedBuildingForester;
        bFarm.clicked -= PlayerBuildsManagerSystem.setWantedBuildingFarm;
        PlayerStatsManagerSystem.OnVariablesChanged -= updateValues;
    }
    void updateValues()
    {
        VisualElement visualElement = GetComponent<UIDocument>().rootVisualElement;

        Label txtStats = visualElement.Q<Label>("TxtStats");

        txtStats.text = "food " + PlayerStatsManagerSystem.Food + ",wood " + PlayerStatsManagerSystem.Wood + ",stone " + PlayerStatsManagerSystem.Stone + ",Available " + PlayerStatsManagerSystem.BalistaArrows;

    }
}
