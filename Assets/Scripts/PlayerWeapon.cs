using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] Damage weaponType;

    [SerializeField] float missileSpeed;
    [SerializeField] float fireRateDelay;

    Coroutine fireCoroutine;
    bool shouldFire = true;

    

    void Start()
    {
        Fire();
    }

    void Update()
    {

    }

    public void ChangeWeaponAndSprite(Damage newWeapon, int missileSpeedPrefab, float fireRateDelayPrefab, Sprite newSprite)
    {
        shouldFire = true;
        weaponType = newWeapon;
        missileSpeed = missileSpeedPrefab;
        fireRateDelay = fireRateDelayPrefab;
        GetComponent<SpriteRenderer>().sprite = newSprite;
        Fire();

    }

    public void ChangeLaserAndSprite(float fireDelay, Sprite newSprite)
    {
        shouldFire = false;
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }




    private void Fire()
    {
        StopAllCoroutines();
        fireCoroutine = StartCoroutine(FireNonStop());
    }

    IEnumerator FireNonStop()
    {
        while (shouldFire)
        {
            Vector3 weaponSpawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z); // spawns missiles further from player
            Damage laser = Instantiate(weaponType, weaponSpawn, Quaternion.identity) as Damage;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeed);
            yield return new WaitForSeconds(fireRateDelay);
        }
    }
}
