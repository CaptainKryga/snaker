using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBonuses : MonoBehaviour
{
    public GameObject prefabBonus;
    public bool bonusOn;

    private GameObject head;
    private GameObject bonus;
    private int x;
    void Update()
    {
        if (!bonusOn)
        {
            if (x++ > 0)
            {
                head = GetComponent<GameStart>().head;
                while (head.GetComponent<Body>().next != null)
                    head = head.GetComponent<Body>().next;
                head.gameObject.GetComponent<Body>().next = Instantiate(GetComponent<GameStart>().prefab_body);
                GameObject var = head;
                head = head.GetComponent<Body>().next;
                head.name = "body";
                head.transform.position = var.GetComponent<Body>().pos;
                head.GetComponent<Body>().pos = head.transform.position;
            }
            bonus = Instantiate(prefabBonus);
            bonus.name = "bonus";
            bonus.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-4.4f, 4.4f));
            bonusOn = true;
        }
    }
}
