using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance; public bool inGame { get; private set; } public Transform player;

    void Start()
    {
        instance = this;
    }

    void OnMouseUpAsButton()
    {
        if(!inGame)
        {
            inGame = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            player.gameObject.BroadcastMessage("Begin", null, SendMessageOptions.DontRequireReceiver);
            player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            Camera.main.transform.position = new Vector3(0, 0, -10);
        }
    }

    public void End()
    {
        inGame = false;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]);
        }

        objects = GameObject.FindGameObjectsWithTag("star");
        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]);
        }

        objects = GameObject.FindGameObjectsWithTag("pickup");
        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]);
        }

        objects = GameObject.FindGameObjectsWithTag("projectile");
        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]);
        }

        player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }
}
