using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    //akutelle Checkpoint
    public GameObject currentCheckpoint;

    //Spieler GameObject
    public GameObject player;

    public Image noLiveImage;
    public Image noLiveImage1;
    public Image noLiveImage2;

    public Text death;

    public int live;

    public void RespawnPlayer()
    {
        //Leben abziehen
        live--;
        switch(live)
        {
            case 2:
                noLiveImage2.enabled = true;
                break;
            case 1:
                noLiveImage1.enabled = true;
                break;
            case 0:
                noLiveImage.enabled = true;
                break;
            default: death.enabled = true;
                break;
        }
        

        //Player an den Checkpoint setzen
        player.transform.position = currentCheckpoint.transform.position;
    }
}
