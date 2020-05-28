using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    //akutelle Checkpoint
    public GameObject currentCheckpoint;

    //Spieler GameObject
    public GameObject player;

    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
    }
}
