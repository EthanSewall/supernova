using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    bool goingNova; bool expand; Collider2D[] preAlloc; int amount; float defaultScale;
    public LayerMask theMask; public float rate; public float maxRadius; public int damage;

    void Start()
    {
        goingNova = expand = false;
        preAlloc = new Collider2D[10];
        defaultScale = transform.localScale.x;
    }

    void Update()
    {
        if(goingNova)
        {
            if (expand)
            {
                transform.localScale *= (1 + Time.deltaTime * rate * maxRadius);

                if(transform.localScale.x > maxRadius)
                {
                    if ((amount = Physics2D.OverlapCircleNonAlloc(transform.position, transform.localScale.x * 0.85f, preAlloc, theMask)) > 0)
                    {
                        for (int i = 0; i < amount; i++)
                        {
                            if (preAlloc[i].GetComponent<health>())
                            {
                                preAlloc[i].GetComponent<health>().TakeDamage(damage);
                            }
                        }
                    }
                    Destroy(gameObject);
                }
            }
            else
            {
                transform.localScale *= (1 - Time.deltaTime * rate);
                if(transform.localScale.x < defaultScale * 0.2f)
                {
                    expand = true;
                }
            }
        }
    }

    void OnZeroHP()
    {
        goingNova = true;
    }
}
