using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime;

    private void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
