using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public void gameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
