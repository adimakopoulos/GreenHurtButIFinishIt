using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerSystem : MonoBehaviour
{
    public GameObject TilePreFab;
    public static Dictionary<Vector2, TileManager> map = new Dictionary<Vector2, TileManager>();
    public static int x, y;
    private void Awake()
    {
        TilePreFab = Resources.Load("Prefabs/TileGo") as GameObject;
    }
    public static bool validateCanBuildOnTile(List<Vector2> positions)
    {
        bool isPossibleToBuild = true;
        foreach (Vector2 pos in positions)
        {
            if (map.ContainsKey(pos) && map[pos].navTypeEnum != NavTypesEnum.EMPTY)
            {
                isPossibleToBuild = false;
            } 
        }
        return isPossibleToBuild;

    }

    public static bool validateIsOnFeritleOrGrassTile(List<Vector2> positions)
    {
        List<bool> boolResultForEveryTile = new List<bool>();
        foreach (Vector2 pos in positions)
        {
            if (map.ContainsKey(pos) &&
                map[pos].tileTypeEnum == TileTypesEnum.GRASS ||
                map[pos].tileTypeEnum == TileTypesEnum.FERTILE)
            {
                boolResultForEveryTile.Add(true);
            }
            else {
                boolResultForEveryTile.Add(false);
            }
        }

        //check all results to make sure all of them are grass or feritle
        foreach (bool result in boolResultForEveryTile)
        {
            if (!result) {
                return false;
            }
        }

        return true;

    }
    public static void setTilesType(List<Vector2> positions, NavTypesEnum navTypesEnum ) {
        foreach (Vector2 pos in positions) {
            map[pos].setNavTypeEnum(navTypesEnum);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        populateMapWithTiles();
    }

    private void populateMapWithTiles()
    {
        x = 10;
        y = 20;
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                createAndPlaceTile(i, j);
            }
        }
    }

    private void createAndPlaceTile(int i, int j)
    {
        var tileGO = Instantiate(TilePreFab);
        tileGO.transform.position = new Vector3(j * 1, 0, i * 1);
        tileGO.name = "Tile: " + j + " " + i;
        tileGO.GetComponent<TileManager>().location = new Vector2(j, i);
        map.Add(new Vector2(j, i), tileGO.GetComponent<TileManager>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
