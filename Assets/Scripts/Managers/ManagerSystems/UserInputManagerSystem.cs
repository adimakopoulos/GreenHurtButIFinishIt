using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputManagerSystem : MonoBehaviour
{
    Plane plane = new Plane(Vector3.up, 0);
    float distance;


    static Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            PlayerBuildsManagerSystem.setWantedBuildingNone();
        }



        setWorldPositionUsingPlane();

    }

    private void setWorldPositionUsingPlane()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
    }

    public static Vector3 getWorldPosition() {
        return worldPosition;
    }


}
