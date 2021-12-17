using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthUI : MonoBehaviour
{
    public TextMesh theText; public health theHealth;

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
        if (theHealth.currentHP > 0)
        {
            theText.text = "Shields at " + theHealth.currentHP + "%";
        }
        else
        {
            theText.text = ":(";
            MainMenu.instance.End();
        }
    }
}
