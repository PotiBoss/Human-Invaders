using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damageValue = 10;

    public float GetDamage()
    {
        return damageValue;
    }

    public void Hit()
    {
        {
            Destroy(gameObject);
        }
    }

    public void HealthToReduce()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            float healthToReduce = collision.gameObject.GetComponent<Enemy>().GetHealth();
            if (damageValue - healthToReduce <= 0)
            {
                Hit();
            }
            else
            {
                damageValue -= healthToReduce;
            }
        }
        else
        {
            Hit();
        }

    }
}
