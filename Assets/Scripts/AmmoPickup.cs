using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerController.instance.currentAmmo += ammoAmmount;
            PlayerController.instance.updateAmmoUi();
            
            AudioController.instance.PlayAmmoPickup();

            Destroy(gameObject);
        }
    }
}
