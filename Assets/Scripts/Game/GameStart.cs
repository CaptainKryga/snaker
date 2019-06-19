using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject prefab_head;
    public GameObject prefab_body;

    public GameObject head;
    private GameObject body;
    private GameObject headBody;
    private float delay, x, y;
    void Start()
    {
        x = -1.1f;
        y = 0;
        delay = 1;
        head = Instantiate(prefab_head);
        head.name = "head";
        head.transform.position = new Vector2(0, 0);
        body = Instantiate(prefab_body);
        body.name = "body";
        body.transform.position = new Vector2(head.transform.position.x + 1.1f, head.transform.position.y);
        head.GetComponent<Body>().next = body;
        head.GetComponent<Body>().pos = head.GetComponent<Body>().next.transform.position;
    }
    void Update()
    {
        if (GetComponent<GameController>().GameOn && !GetComponent<GameController>().GameOver)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                int flag = 100;
                head.GetComponent<Body>().next.GetComponent<Body>().pos = head.transform.position;
                head.transform.position = new Vector2(head.transform.position.x + x, head.transform.position.y + y);
                headBody = head.GetComponent<Body>().next;
                while (true)
                {
                    flag--;
                    if (headBody.GetComponent<Body>().next)
                        headBody.GetComponent<Body>().next.GetComponent<Body>().pos = headBody.transform.position;
                    headBody.transform.position = headBody.GetComponent<Body>().pos;
                    if (headBody.GetComponent<Body>().next == null)
                        break;
                    headBody = headBody.GetComponent<Body>().next;
                    if (flag < 0)
                    {
                        break;
                    }
                }
                delay = 0.5f;
            }
        }

        PressKey();
    }

    private void PressKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            x = 0;
            y = 1.1f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            x = 0;
            y = -1.1f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            x = -1.1f;
            y = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) ||  Input.GetKeyDown(KeyCode.D))
        {
            x = 1.1f;
            y = 0;
        }
    }
}
