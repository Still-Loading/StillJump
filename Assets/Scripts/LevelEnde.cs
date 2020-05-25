using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnde : MonoBehaviour
{

    public Text endeAusgabe;
    public Text gameScore;
    public Text endScore;

    void Start()
    {
        endeAusgabe.enabled = false;
        endScore.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Level Ende");
            endeAusgabe.enabled = true;
            endScore.text = gameScore.text;
            endScore.enabled = true;
            gameScore.enabled = false;
        }
    }
}
