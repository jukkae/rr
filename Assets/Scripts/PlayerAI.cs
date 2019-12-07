using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    N, NE, E, SE, S, SW, W, NW, None
}

static class DirectionMethods
{
    public static Vector3 GetVector3(Direction d)
    {
        switch (d)
        {
            case Direction.N:
                return new Vector3(0, 0, 1);
            case Direction.NE:
                return new Vector3(1, 0, 1);
            case Direction.E:
                return new Vector3(1, 0, 0);
            case Direction.SE:
                return new Vector3(1, 0, -1);
            case Direction.S:
                return new Vector3(0, 0, -1);
            case Direction.SW:
                return new Vector3(-1, 0, -1);
            case Direction.W:
                return new Vector3(-1, 0, 0);
            case Direction.NW:
                return new Vector3(-1, 0, 1);
            default:
                return new Vector3(0, 0, 0);
        }
    }
}

public class PlayerAI : MonoBehaviour
{

    private World world;

    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
    }

    void Update()
    {
        Direction direction = Direction.None;
        if (Input.GetKeyDown("q"))
        {
            direction = Direction.NW;
        }
        if (Input.GetKeyDown("w"))
        {
            direction = Direction.N;
        }
        if (Input.GetKeyDown("e"))
        {
            direction = Direction.NE;
        }
        if (Input.GetKeyDown("a"))
        {
            direction = Direction.W;
        }
        if (Input.GetKeyDown("d"))
        {
            direction = Direction.E;
        }
        if (Input.GetKeyDown("z"))
        {
            direction = Direction.SW;
        }
        if (Input.GetKeyDown("x"))
        {
            direction = Direction.S;
        }
        if (Input.GetKeyDown("c"))
        {
            direction = Direction.SE;
        }
        if(direction != Direction.None)
        {
            Vector3 nextPos = transform.position + DirectionMethods.GetVector3(direction);
            Vector2Int nextPosXY = new Vector2Int(Mathf.RoundToInt(nextPos.x), Mathf.RoundToInt(nextPos.z)); // shit but eh who cares
            if (world.IsWalkable(nextPosXY.x, nextPosXY.y))
            {
                transform.Translate(DirectionMethods.GetVector3(direction));
            }
        }
    }
}
