using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private List<GameObject> _shipListPrefab;
    private GameObject _currentShipPrefabs;
    private GameObject _playerShip;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        _currentShipPrefabs = _shipListPrefab[0];
    }
    public void PlayGame()
    {
        if (_playerShip != null) Destroy(_playerShip);
        _playerShip = Instantiate(_currentShipPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Current Ship: " + _currentShipPrefabs.name);
        DontDestroyOnLoad(_playerShip);
    }
    public void GameOver()
    {
        if (_playerShip != null)
        {
            Destroy(_playerShip);
            _playerShip = null;
        }
        SceneManager.LoadScene(0);
    }
    public void ChangeShip()
    {
        _currentShipPrefabs = _shipListPrefab[1 - _shipListPrefab.IndexOf(_currentShipPrefabs)];
    }
}

public enum Scene
{
    MENU = 0,
    GAME = 1
}
