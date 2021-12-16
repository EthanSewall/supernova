using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] spawns;
    public float rate; public int cap;
    public Vector2 xRange; public Vector2 yRange;
    float counter;

    void Start()
    {
        counter = rate - 0.5f;
    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter > rate)
        {
            counter = 0;
            if (GameObject.FindGameObjectsWithTag("enemy").Length < cap)
            {
                float foo = Random.value;
                if (foo > 0.9f)
                {
                    foo = 2;
                }
                else if (foo > 0.6f)
                {
                    foo = 1;
                }
                else
                {
                    foo = 0;
                }

                Vector2 position = new Vector2();

                for (int i = 0; i < 1; i++)
                {
                    position = new Vector2(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y));
                    if (Vector2.Distance(position, player.position) < 10) { i--; }
                }

                Instantiate(spawns[(int)foo], position, Quaternion.identity);
            }
        }
    }
}
