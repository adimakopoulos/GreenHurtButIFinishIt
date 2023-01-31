using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStore : MonoBehaviour
{
    public static int FarmWoodCost = 50;

    public static int QuaryWoodCost = 70;
    public static int QuaryStoneCost = 50;

    public static int ForesterWoodCost = 40;



    public static bool buyFarm() {
        if (PlayerStatsManagerSystem.Wood >= FarmWoodCost) {
            PlayerStatsManagerSystem.Wood -= FarmWoodCost;
            return true;
        }
        return false;
    }
    public static bool buyQuary()
    {
        if (PlayerStatsManagerSystem.Wood >= QuaryWoodCost && PlayerStatsManagerSystem.Stone >= QuaryStoneCost)
        {
            PlayerStatsManagerSystem.Wood -= 70;
            PlayerStatsManagerSystem.Stone -= 50;
            return true;
        }
        return false;
    }
    public static bool buyForester()
    {
        if (PlayerStatsManagerSystem.Wood >= 40)
        {
            PlayerStatsManagerSystem.Wood -= 40;
            return true;
        }
        return false;
    }

}

