using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void EndGame() {
        
        Invoke("RestartGame", 2.0f);

    }
    void RestartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
