using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{


    public void Setup(int score)
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Demo_Scene");
    }
        public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
