using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int maxHP;
    int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        BroadcastMessage("OnDamage", null, SendMessageOptions.DontRequireReceiver);

        if (currentHP <= 0)
        {
            BroadcastMessage("OnZeroHP", null, SendMessageOptions.DontRequireReceiver);
        }

    }
}
