using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colObject;

    public float speed;

    private bool shouldOpen;

    private void Update()
    {
        if (shouldOpen && doorModel.position.z != 1f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position,
                new Vector3(doorModel.position.x, doorModel.position.y, 1f), speed * Time.deltaTime);
            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        }
        else if (!shouldOpen && doorModel.position.z != 0f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position,
                new Vector3(doorModel.position.x, doorModel.position.y, 0f), speed * Time.deltaTime);
            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
        }
    }
}
