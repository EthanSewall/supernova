using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<health>())
        {
            if (!(gameObject.layer == 13 && collision.gameObject.CompareTag("star")))
            {
                collision.gameObject.GetComponent<health>().TakeDamage(damage);
            }
        }
            Destroy(gameObject);
    }
}
