using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] Damage weaponType;

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

    public void ChangeWeaponAndSprite(Damage newWeapon, Sprite newSprite)
    {
        weaponType = newWeapon;
        GetComponent<SpriteRenderer>().sprite = newSprite;
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
            Damage laser = Instantiate(weaponType, weaponSpawn, Quaternion.identity) as Damage;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeed);
            yield return new WaitForSeconds(fireRateDelay);
        }
    }
}
