using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Wall, Floor
}

public class Tile
{
    public TileType type;
    public Tile(TileType t) => type = t;
}

public class World : MonoBehaviour
{
    public int width = 80;
    public int height = 40;

    public GameObject floorTile;
    public GameObject wallTile;
    public GameObject pointLight;

    private GameObject map;

    Tile[,] tiles;

    void Start()
    {
        MapGenerator.GenerateMap(width, height);
        map = new GameObject
        {
            name = "Map"
        };

        map.transform.parent = transform;
        tiles = new Tile[width, height];
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(i == 0 || i == width - 1 || j == 0 || j == height - 1)
                {
                    tiles[i, j] = new Tile(TileType.Wall);
                    var g = Instantiate(wallTile, new Vector3(i, 0, j), Quaternion.identity);
                    g.transform.parent = map.transform;
                }
                else
                {
                    tiles[i, j] = new Tile(TileType.Floor);
                    var g = Instantiate(floorTile, new Vector3(i, 0, j), Quaternion.identity);
                    g.transform.parent = map.transform;
                }
                if(i % 10 == 0 && j % 10 == 0)
                {
                    var g = Instantiate(pointLight, new Vector3(i, 3, j), Quaternion.identity);
                    g.transform.parent = map.transform;
                }
            }
        }
    }
    
    void Update()
    {
        
    }

    public bool IsWalkable(int x, int y)
    {
        return tiles[x, y].type == TileType.Floor;
    }
}
