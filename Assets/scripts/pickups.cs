using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour
{
    public Transform player;
    public GameObject spawn;
    public float rate; public int cap;
    public Vector2 xRange; public Vector2 yRange;
    float counter;

    void Start()
    {
        counter = rate - 0.5f;
    }

    void Update()
    {
        if (MainMenu.instance.inGame)
        {
            counter += Time.deltaTime;
            if (counter > rate)
            {
                counter = 0;
                if (GameObject.FindGameObjectsWithTag("pickup").Length < cap)
                {
                    Vector2 position = new Vector2();

                    for (int i = 0; i < 1; i++)
                    {
                        position = new Vector2(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y));
                        if (Vector2.Distance(position, player.position) < 10) { i--; }
                    }

                    Instantiate(spawn, position, Quaternion.identity);
                }
            }
        }
    }
}
