using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject weaponType;

    [SerializeField] float missileSpeed;
    [SerializeField] float fireRateDelay;

    Coroutine fireCoroutine;

    

    void Start()
    {
        Fire();
    }

    void Update()
    {

    }

    private void Fire()
    {
        fireCoroutine = StartCoroutine(FireNonStop());
    }

    IEnumerator FireNonStop()
    {
        while (true)
        {
            Vector3 weaponSpawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z); // spawns missiles further from player
            GameObject laser = Instantiate(weaponType, weaponSpawn, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeed);
            yield return new WaitForSeconds(fireRateDelay);
        }
    }
}
