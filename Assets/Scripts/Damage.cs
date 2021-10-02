using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damageValue;
    float startingDamageValue;

    float laserDamage = 5f;
    float healthToReduce;

    private void Start()
    {
        startingDamageValue = damageValue;
    }

    public float GetDamage()
    {
        return damageValue;
    }

    public void ReduceDamage(float health)
    {
        if (!gameObject.GetComponent<LaserWeapon>())
        {
            damageValue -= health;
        }
    }


    public void Hit()
    {
        damageValue = startingDamageValue;
        Destroy(gameObject);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            float healthToReduce = collision.gameObject.GetComponent<Enemy>().GetHealth();

            Debug.Log(healthToReduce);
            Debug.Log(damageValue);
            if (gameObject.GetComponent<LaserWeapon>())
            {
                collision.gameObject.GetComponent<Enemy>().ProcessHit(GetComponent<Damage>());
            }

            else if (damageValue - healthToReduce <= 0)
            {
                Hit();
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
