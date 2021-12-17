using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject projectile; public float rate; public int startingAmmo; public float velocity;
    int currentAmmo; float counter; public TextMesh theText;

    void Start()
    {
        Begin();
    }

    void Update()
    {
        if (MainMenu.instance.inGame)
        {
            if (counter > rate)
            {
                if (Input.GetButtonDown("Fire"))
                {
                    if (currentAmmo > 0)
                    {
                        GameObject obj = Instantiate(projectile, transform.position, transform.rotation);
                        obj.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * velocity, ForceMode2D.Impulse);
                        currentAmmo--;
                        counter = 0;
                        UpdateAmmo();
                    }
                }
            }
            else
            {
                counter += Time.deltaTime;
            }
        }
    }

    public void Begin()
    {
        counter = rate + 0.1f;
        currentAmmo = startingAmmo;
        UpdateAmmo();
    }

    void UpdateAmmo()
    {
        theText.text = currentAmmo.ToString() + " Ammo";
    }

    public void Load(int amount)
    {
        currentAmmo += amount;
        UpdateAmmo();
    }
}
