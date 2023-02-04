using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatsManagerSystem : MonoBehaviour
{
    public static event System.Action OnVariablesChanged;
    private static int wood = 100, stone = 100, food = 100;
    private static int balistaArrows = 100;
    public static int PAttack = 50;
    private static float ammountOfTime = 5f;
    private static int health = 100;

    public static int Food { get => food; set { food = value; OnVariablesChanged?.Invoke(); } }
    public static int Stone { get => stone; set { stone = value; OnVariablesChanged?.Invoke(); } }
    public static int Wood { get => wood; set { wood = value; OnVariablesChanged?.Invoke(); } }
    public static int BalistaArrows { get => balistaArrows; set { balistaArrows = value; OnVariablesChanged?.Invoke(); } }

    public static float AmmountOfTime { get => ammountOfTime; set => ammountOfTime = value; }
    public static int Health
    {
        get => health;
        set
        {
            health = value;
            if (health < 1)
            {
                Debug.Log("GAME OVER"); 
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void increaseWood(int amount)
    {
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
}
