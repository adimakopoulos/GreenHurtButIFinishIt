using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManagerSystem : MonoBehaviour
{
    public List<Vector2> road = new List<Vector2>();
    private int lastDirection = 0; //0 is onward, 
    public static List<GameObject> allRoadTiles = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Invoke("offsetRoadTiles", 0.4f);

        int i = 39;
        int j = 10;
        while (i > 20)
        {


            var randDecision = Random.Range(0, 3);
            if (lastDirection ==1 && randDecision == 2) {
                continue;
            }
            if (lastDirection == 2 && randDecision == 1)
            {
                continue;
            }
            //Debug.Log(randDecision);
            if (randDecision == 0)
            {
                i--;
                road.Add(new Vector2(i, j));
                lastDirection = 0;

                continue;
            }
            if (randDecision == 1 && j<19 && j>1)
            {
                //Debug.Log("right");
                ++j;
                road.Add(new Vector2(i, j));
                lastDirection = 1;

                continue;
            }
            if (randDecision == 2 && j < 19 && j > 1)
            {
                //Debug.Log("left");
                --j;
                road.Add(new Vector2(i,j));
                lastDirection = 2;

                continue;
            }
            i--;
            road.Add(new Vector2(i, j));
            lastDirection = 0;


        }


    }

    private void offsetRoadTiles()
    {
        foreach (var vector2 in road)
        {
            var pos = GridManagerSystem.map[vector2].gameObject.transform.localPosition;
            pos.y = -0.2f;
            GridManagerSystem.map[vector2].gameObject.transform.localPosition = pos;
            allRoadTiles.Add(GridManagerSystem.map[vector2].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
