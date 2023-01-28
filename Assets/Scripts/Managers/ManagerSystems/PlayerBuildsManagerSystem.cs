using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildsManagerSystem : MonoBehaviour
{
    static PlayerBuildTypeEnum playerBuildTypeEnum = PlayerBuildTypeEnum.NONE;
    public static GameObject quarryPrefab;
    public static GameObject foresterPrefab;
    public static GameObject farmPrefab;

    public static GameObject GhostInstanciatedPrefab;
    private static float tileDelay = 2f;
    private void Awake()
    {
        quarryPrefab = Resources.Load("Prefabs/QuarryGO") as GameObject;
        foresterPrefab = Resources.Load("Prefabs/ForesterGO") as GameObject;
        farmPrefab = Resources.Load("Prefabs/FarmGO") as GameObject;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GhostInstanciatedPrefab != null)
        {
            validatePositionToBeInsideMap();
        }

        tileDelay -= Time.deltaTime;
        if (Input.GetMouseButtonUp(0) && tileDelay < 0)
        {
            placeWantedBuilding();
        }


    }

    private static void validatePositionToBeInsideMap()
    {
        int posX = Mathf.FloorToInt(UserInputManagerSystem.getWorldPosition().x);
        int posY = Mathf.FloorToInt(UserInputManagerSystem.getWorldPosition().z);
        posX = posX < 0 ? 0 : posX;
        posY = posY < 0 ? 0 : posY;
        posX = posX >= GridManagerSystem.x ? GridManagerSystem.x : posX;
        posY = posY >= GridManagerSystem.y ? GridManagerSystem.y : posY;

        MakeGhostInstanciatedPrefabeThatFollowsMouse(posX, posY);

    }

    private static void MakeGhostInstanciatedPrefabeThatFollowsMouse(int posX, int posY)
    {
        GhostInstanciatedPrefab.GetComponent<IValidPosition>().SetMaterialIfInvalid(validatePosition(posX, posY));

        isFarmOnValidTileType(posX, posY);

        GhostInstanciatedPrefab.transform.position = new Vector3(posX, Mathf.Lerp(0f, 1f, Time.deltaTime), posY);


    }

    private static void isFarmOnValidTileType(int posX, int posY)
    {
        if (GhostInstanciatedPrefab.name.Contains("Farm"))
        {
            GhostInstanciatedPrefab.GetComponent<IValidPosition>().SetMaterialIfInvalid(GridManagerSystem.validateIsOnFeritleOrGrassTile(collisionForFarm(posX, posY)));
        }
    }

    private static bool hasFertileLandBelow(int x, int y) {
        
        return false;
    }


    static bool canBuild = false;
    private static bool validatePosition(int x, int y)
    {

        if (playerBuildTypeEnum == PlayerBuildTypeEnum.FARM)
        {

            return GridManagerSystem.validateCanBuildOnTile(collisionForFarm(x, y));

        }
        else if (playerBuildTypeEnum == PlayerBuildTypeEnum.QUARRY)
        {

            return GridManagerSystem.validateCanBuildOnTile(collisionForQuarry(x, y));

        }
        else if (playerBuildTypeEnum == PlayerBuildTypeEnum.FORESTER)
        {

            return GridManagerSystem.validateCanBuildOnTile(collisionForForester(x, y));

        }
        return false;
    }

    private static List<Vector2> collisionForForester(int x, int y)
    {
        List<Vector2> tilesToBeChanged = new List<Vector2>();

        tilesToBeChanged.Add(new Vector2(x, y));
        tilesToBeChanged.Add(new Vector2(x + 1, y));
        return tilesToBeChanged;
    }

    private static List<Vector2> collisionForQuarry(int x, int y)
    {
        List<Vector2> tilesToBeChanged = new List<Vector2>();

        tilesToBeChanged.Add(new Vector2(x, y));
        return tilesToBeChanged;

    }

    private static List<Vector2> collisionForFarm(int x, int y)
    {
        List<Vector2> tilesToBeChanged = new List<Vector2>();

        tilesToBeChanged.Add(new Vector2(x, y));
        tilesToBeChanged.Add(new Vector2(x + 1, y));
        tilesToBeChanged.Add(new Vector2(x, y + 1));
        tilesToBeChanged.Add(new Vector2(x + 1, y + 1));
        return tilesToBeChanged;

    }

    //gets called by UI Button
    public static void setWantedBuildingQuarry()
    {

        if (GhostInstanciatedPrefab != null && !GhostInstanciatedPrefab.name.Contains("Quarry"))
            Destroy(GhostInstanciatedPrefab);
        tileDelay = 0.5f;
        playerBuildTypeEnum = PlayerBuildTypeEnum.QUARRY;
        GhostInstanciatedPrefab = Instantiate(quarryPrefab);

    }
    //gets called by UI Button
    public static void setWantedBuildingFarm()
    {
        if (GhostInstanciatedPrefab != null && !GhostInstanciatedPrefab.name.Contains("Farm"))
            Destroy(GhostInstanciatedPrefab);
        tileDelay = 0.5f;
        playerBuildTypeEnum = PlayerBuildTypeEnum.FARM;
        GhostInstanciatedPrefab = Instantiate(farmPrefab);

    }

    //gets called by UI Button
    public static void setWantedBuildingForester()
    {

        if (GhostInstanciatedPrefab != null && !GhostInstanciatedPrefab.name.Contains("Forester"))
            Destroy(GhostInstanciatedPrefab);
        tileDelay = 0.5f;
        playerBuildTypeEnum = PlayerBuildTypeEnum.FORESTER;
        GhostInstanciatedPrefab = Instantiate(foresterPrefab);

    }

    public static void setWantedBuildingNone()
    {
        playerBuildTypeEnum = PlayerBuildTypeEnum.NONE;
        Destroy(GhostInstanciatedPrefab);
    }
    private static void placeWantedBuilding()
    {
        int posX = Mathf.FloorToInt(UserInputManagerSystem.getWorldPosition().x);
        int posY = Mathf.FloorToInt(UserInputManagerSystem.getWorldPosition().z);
        if (validatePosition(posX, posY))
        {
            if (playerBuildTypeEnum == PlayerBuildTypeEnum.FARM)
            {
                GridManagerSystem.setTilesType(collisionForFarm(posX, posY), NavTypesEnum.WALKABLE);
            }
            else if (playerBuildTypeEnum == PlayerBuildTypeEnum.FORESTER)
            {
                GridManagerSystem.setTilesType(collisionForForester(posX, posY), NavTypesEnum.OCCUPIED);

            }
            else if (playerBuildTypeEnum == PlayerBuildTypeEnum.QUARRY)
            {
                GridManagerSystem.setTilesType(collisionForQuarry(posX, posY), NavTypesEnum.OCCUPIED);

            }

            playerBuildTypeEnum = PlayerBuildTypeEnum.NONE;
            GhostInstanciatedPrefab = null;
        }

    }

}

public enum PlayerBuildTypeEnum
{
    NONE,
    QUARRY,
    FORESTER,
    FARM,

}
