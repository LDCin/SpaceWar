using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _customCanvas;

    private void Awake()
    {
        _menuCanvas.SetActive(true);
        _customCanvas.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.PlayGame();
    }
    public void Custom()
    {
        _menuCanvas.SetActive(false);
        _customCanvas.SetActive(true);
    }
    public void BackToMenu()
    {
        _menuCanvas.SetActive(true);
        _customCanvas.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
