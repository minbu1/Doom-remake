using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammoPickup, enemyDeath, enemyShot, gunShot, healthSound, playerHurt, enemyShoot;

    private void Awake()
    {
        instance = this;
    }

    public void PlayAmmoPickup()
    {
        ammoPickup.Stop();
        ammoPickup.Play();
    }
    public void PlayEnemyDeath()
    {
        enemyDeath.Stop();
        enemyDeath.Play();
    }
    public void PlayEnemyShot()
    {
        enemyShot.Stop();
        enemyShot.Play();
    }
    public void PlayGunShot()
    {
        gunShot.Stop();
        gunShot.Play();
    }
    public void PlayHealthSound()
    {
        healthSound.Stop();
        healthSound.Play();
    }
    public void PlayPlayerHurt()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }
}
