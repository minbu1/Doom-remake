using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamEffects : MonoBehaviour
{
    public GameObject damageScreen;
    public float damageScreenOnTime = 0.5f;
    
    
    public void DamageScreenOn()
    {
        damageScreen.SetActive(true);
        Invoke("DamageScreenOff", damageScreenOnTime);
    }

    private void DamageScreenOff()
    {
        damageScreen.SetActive(false);
    }
}
