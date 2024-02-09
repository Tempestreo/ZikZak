using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        Vector3 playerPos = player.gameObject.transform.position;
        this.transform.position = new Vector3(playerPos.x, this.transform.position.y, playerPos.z);
    }
}
