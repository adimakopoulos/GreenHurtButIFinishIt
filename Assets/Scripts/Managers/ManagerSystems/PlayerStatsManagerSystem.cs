using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatsManagerSystem: MonoBehaviour
{
    public static event System.Action OnVariablesChanged;
    private static int wood,stone,food;

    public static int Food { get => food; set  { food = value; OnVariablesChanged.Invoke(); }  }
    public static int Stone { get => stone; set  { stone = value; OnVariablesChanged.Invoke(); }  }
    public static int Wood { get => wood; set  { wood = value; OnVariablesChanged.Invoke(); }  }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void increaseWood(int amount) {
        wood += amount;
    }
    public static void increaseStone(int amount)
    {
        stone += amount;
    }
    public static void increaseFood(int amount)
    {
        Food += amount;
    }
    public static string toString() {
        return "wood: " + wood + " stone: " + stone;
    }
}
