using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        LockCursor();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        if(Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
