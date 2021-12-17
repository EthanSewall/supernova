using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform followThis;
    public Vector2 xRange;
    public Vector2 yRange;

    void Update()
    {
        if (MainMenu.instance.inGame)
        {
            Vector3 vect = Vector3.zero;

            vect.x = followThis.position.x;
            vect.x = Mathf.Clamp(vect.x, xRange.x, xRange.y);
            vect.y = followThis.position.y;
            vect.y = Mathf.Clamp(vect.y, yRange.x, yRange.y);
            vect.z = -10;

            transform.position = vect;
        }
    }
}
