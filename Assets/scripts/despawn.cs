using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{
    public float theTime;
    float delay;

    void Update()
    {
        delay += Time.deltaTime;
        if(delay > theTime)
        {
            Destroy(gameObject);
        }
    }
}
