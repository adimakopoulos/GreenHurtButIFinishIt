using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Vector2 location;
    public List<Material> materials = new List<Material>();
    public  TileTypesEnum tileTypeEnum;
    public NavTypesEnum navTypeEnum = NavTypesEnum.EMPTY;
    public MeshRenderer MeshRender;
    public Animator animator;

    public void setNavTypeEnum(NavTypesEnum navTypesEnum) { 
        this.navTypeEnum = navTypesEnum;
    }
    private void Awake()
    {
        Invoke("setRandomTileTypeEnum", 0.5f);
    }

    private void OnMouseDown()
    {
        //animator.Play("TileSelection");
    }

    public void setLocation(Vector2 location)
    {
        this.location = location;
    }

    private void setRandomTileTypeEnum()
    {
        float perlinNoise;

        perlinNoise = Mathf.PerlinNoise(location.x*0.33f, location.y * 0.33f);

        if (perlinNoise > 0.8)
        {
            tileTypeEnum = TileTypesEnum.FERTILE;
            MeshRender.material = materials[0];
        }
        else if (perlinNoise <= 0.8 && perlinNoise >= 0.5)
        {
            tileTypeEnum = TileTypesEnum.GRASS;
            MeshRender.material = materials[1];

        }
        else
        {
            tileTypeEnum = TileTypesEnum.DIRT;
            MeshRender.material = materials[2];

        }
        if(gameObject.transform.position.y<-0.11)
        {
            tileTypeEnum = TileTypesEnum.ROAD;
            MeshRender.material = materials[3];

        }

    }

}
public enum TileTypesEnum
{
    GRASS,
    FERTILE,
    DIRT,
    ROAD
}

public enum NavTypesEnum
{
    WALKABLE,
    OCCUPIED,
    EMPTY,
}
