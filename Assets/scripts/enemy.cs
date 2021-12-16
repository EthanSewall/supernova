using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target; public float aggroRange; bool aggro = false; float counter = 0; public float speed;
    Vector2 offset; public GameObject projectile; public float fireRate; float delay = 0; public float projectileVelocity;

    void Start()
    {
        offset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }

    void Update()
    {
        if(aggro)
        {
            Vector3 vect = transform.position - target.position;
            transform.up = (new Vector2(vect.x, vect.y)) * -1;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)target.position + offset, speed * Time.deltaTime);

            delay += Time.deltaTime;
            if(delay > fireRate)
            {
                delay = 0;
                GameObject obj = Instantiate(projectile, transform.position, transform.rotation);
                obj.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * projectileVelocity, ForceMode2D.Impulse);
            }

            counter += Time.deltaTime;
            if (counter > 0)
            {
                if (Vector2.Distance(transform.position, target.position) > aggroRange)
                {
                    aggro = false;
                }
                else
                {
                    counter = -Random.value * 1.5f;
                }
            }
        }
        else
        {
            counter += Time.deltaTime;
            if(counter > 0)
            {
                if(Vector2.Distance(transform.position, target.position) < aggroRange)
                {
                    aggro = true;
                }
                else
                {
                    counter = -Random.value * 1.5f;
                }
            }
        }
    }

    public void OnZeroHP()
    {
        Destroy(gameObject);
    }
}
