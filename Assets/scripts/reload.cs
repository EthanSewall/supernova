using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reload : MonoBehaviour
{
    int amount;

    void Start()
    {
        amount = Random.Range(1, 6);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<launcher>().Load(amount);
            Destroy(gameObject);
        }
    }
}
