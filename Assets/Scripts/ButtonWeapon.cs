using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWeapon : MonoBehaviour
{
    [Header("Weapon Set")]
    [SerializeField] Damage weaponPrefab;
    [SerializeField] int missileSpeedPrefab;
    [SerializeField] float fireRateDelayPrefab;

    [Header("Sprite Set")]
    [SerializeField] Sprite shipSprite;


    public void ChangeWeaponAndShip()
    {
        FindObjectOfType<PlayerWeapon>().ChangeWeaponAndSprite(weaponPrefab, missileSpeedPrefab, fireRateDelayPrefab, shipSprite);
    }

}
