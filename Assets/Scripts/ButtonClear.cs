using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClear : MonoBehaviour
{
    public void ClearEnemyBullets()
    {
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyWeapon");
        foreach (GameObject enemyBullet in enemyBullets)
        {
            GameObject.Destroy(enemyBullet);
        }
    }
}
