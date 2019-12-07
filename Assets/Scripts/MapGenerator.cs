using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapGenerator
{
    public static Tile[,] GenerateMap(int width, int height)
    {
        Tile[,] tiles = new Tile[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == 0 || i == width - 1 || j == 0 || j == height - 1)
                {
                    tiles[i, j] = new Tile(TileType.Wall);
                }
                else
                {
                    tiles[i, j] = new Tile(TileType.Floor);
                }
            }
        }

        return tiles;
    }
}
