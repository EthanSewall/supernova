using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthUI : MonoBehaviour
{
    public SpriteRenderer render; public health theHealth; public Sprite[] sprites;

    void Start()
    {
        UpdateHealth();
    }

    public void Begin()
    {
        UpdateHealth();
    }

    public void OnDamage()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (theHealth.currentHP >= 0)
        {
            render.sprite = sprites[theHealth.currentHP / 10];
        }
        else
        {
            render.sprite = sprites[0];
        }
    }

    public void OnZeroHP()
    {
        MainMenu.instance.End();
    }
}
