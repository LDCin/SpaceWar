using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // else Destroy(gameObject);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}

public enum Scene
{
    MENU = 0,
    GAME = 1
}
