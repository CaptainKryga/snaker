using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject next;
    public Vector2 pos;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bonus")
        {
            Destroy(collision.gameObject);
            print("bonus");
            GameObject.Find("GameController").GetComponent<RespawnBonuses>().bonusOn = false;
            GameObject.Find("GameController").GetComponent<GameController>().score++;
            
        }
        else
        {
            GameObject.Find("GameController").GetComponent<GameController>().GameOver = true;
            print("game over");
        }
    }
}
