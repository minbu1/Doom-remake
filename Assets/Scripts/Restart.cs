using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ResetScene()
    {
        GameManager gameManager = new GameManager();
        gameManager.LockCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
