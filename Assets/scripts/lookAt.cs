using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public LayerMask mask; 
    Ray ray; RaycastHit hit; 

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, mask))
        {
            Vector3 vect = transform.position - hit.point;
            transform.up = (new Vector2(vect.x, vect.y)) * -1;
        }
    }
}
