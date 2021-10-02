using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int pointsValue = 150;
    [SerializeField] float health = 100;

    [Header("Shooting")]
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] float projectileSpeed = 20f;

    [Header("Sound Effects")]
    [SerializeField] AudioClip weaponSoundPrefab;
    [SerializeField] float weaponSoundVolume;
    [SerializeField] AudioClip deathSoundPrefab;
    [SerializeField] float deathSoundVolume;

    float shotCounter;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(weaponPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(weaponSoundPrefab, Camera.main.transform.position, weaponSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damageDealer = other.gameObject.GetComponent<Damage>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    public void ProcessHit(Damage damageDealer)
    {
        Debug.Log(health);
        Debug.Log(damageDealer.GetDamage());
        //Debug.Log(health);




        float healthToReduce = health;
        health -= damageDealer.GetDamage();
        damageDealer.ReduceDamage(healthToReduce);


        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSoundPrefab, Camera.main.transform.position, deathSoundVolume);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddPoints(pointsValue);
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
