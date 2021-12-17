using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int damage; Rigidbody2D rb2d; float delay;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.mass = 0.001f;
        delay = -0.125f;
    }

    void Update()
    {
        delay += Time.deltaTime;

        if(delay > 0)
        {
            delay = -Random.value;
            if (GetComponent<BoxCollider2D>().enabled == false)
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<health>())
        {
            collision.gameObject.GetComponent<health>().TakeDamage(damage);
        }
        if (!(gameObject.layer == 13) && collision.gameObject.layer == 12)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            rb2d.velocity = Vector2.zero;
            rb2d.AddRelativeForce(-Vector2.up * 0.5f);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
