using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player"); // should use tags but meh
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + 0.5f, 10, player.transform.position.z + 0.5f);
    }
}
