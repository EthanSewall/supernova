using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxVelocity;
    public float acceleration;

    void Update()
    {
        if(Input.anyKey)
        {
            if(Mathf.Abs(rb2d.velocity.magnitude) < maxVelocity)
            {
                rb2d.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
            }
        }
    }
}
