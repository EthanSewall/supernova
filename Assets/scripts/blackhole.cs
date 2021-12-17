﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour
{
    Collider2D[] preAlloc; int amount; Transform[] forms; public float effectRadius; public float force; public LayerMask layerMask;
    float delay;

    void Start()
    {
        preAlloc = new Collider2D[10];
        delay = 0;
        forms = new Transform[10];
    }


    void Update()
    {
        delay += Time.deltaTime;
        if (delay > 0)
        {
            delay = -Random.value;
            if ((amount = Physics2D.OverlapCircleNonAlloc(transform.position, effectRadius, preAlloc, layerMask)) > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    forms[i] = preAlloc[i].transform;
                }
            }
        }

        if (amount > 0)
        {
            for (int j = 0; j < amount; j++)
            {
                if (forms[j])
                {
                    float dist = Vector2.Distance(forms[j].position, transform.position);
                    forms[j].position = Vector3.MoveTowards(forms[j].position, transform.position, (force * Time.deltaTime) / Vector2.Distance(forms[j].position, transform.position));
                    if (dist < 1)
                    {
                        if (forms[j].gameObject.GetComponent<health>())
                        {
                            forms[j].gameObject.GetComponent<health>().TakeDamage(9999);
                        }
                        else
                        {
                            Destroy(forms[j].gameObject);
                        }
                    }
                }
            }
        }
    }
}
