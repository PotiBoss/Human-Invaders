using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWeapon : MonoBehaviour
{
    [Header("Weapon Set")]
    [SerializeField] Damage weaponPrefab;
    [SerializeField] int missileSpeedPrefab;
    [SerializeField] float fireRateDelayPrefab;
    [SerializeField] LineRenderer laserPrefab;

    [Header("Sprite Set")]
    [SerializeField] Sprite shipSprite;

    [Header("Weapon Buttons")]
    [SerializeField] Button buttonBlue;
    [SerializeField] Button buttonGreen;
    [SerializeField] Button buttonPurple;



    public void ChangeWeapon()
    {
        ChangeWeaponAndShip();
        StartCoroutine(DisableButton());
    }

    IEnumerator DisableButton()
    {
        buttonBlue.enabled = false;
        buttonGreen.enabled = false;
        buttonPurple.enabled = false;
        yield return new WaitForSeconds(1);
        buttonBlue.enabled = true;
        buttonGreen.enabled = true;
        buttonPurple.enabled = true;
    }

    private void ChangeWeaponAndShip()
    {
        DisableLaser();
        FindObjectOfType<PlayerWeapon>().ChangeWeaponAndSprite(weaponPrefab, missileSpeedPrefab, fireRateDelayPrefab, shipSprite);
    }

    public void EnableLaser()
    {
        FindObjectOfType<PlayerWeapon>().ChangeLaserAndSprite(fireRateDelayPrefab, shipSprite);
        laserPrefab.enabled = true;  
    }

    private void DisableLaser()
    {
        laserPrefab.enabled = false;
    }

}
