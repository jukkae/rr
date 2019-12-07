using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIText : MonoBehaviour
{
    GameObject positionText;
    GameObject player;
    void Start()
    {
        positionText = transform.Find("Position").gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        positionText.GetComponent<Text>().text = "position: " + Mathf.RoundToInt(player.transform.position.x) + ", " + Mathf.RoundToInt(player.transform.position.z);
    }
}
