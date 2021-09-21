using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWeapon : MonoBehaviour
{
    [SerializeField] Damage weaponPrefab;
    [SerializeField] Sprite shipSprite;

    public void ChangeWeaponAndShip()
    {
        FindObjectOfType<PlayerWeapon>().ChangeWeaponAndSprite(weaponPrefab, shipSprite);
    }

    public void DestroyEnemyBullets()
    {
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyWeapon");
        foreach (GameObject enemyBullet in enemyBullets)
        {
            GameObject.Destroy(enemyBullet);
        }
    }
}
