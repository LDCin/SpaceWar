using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 1f;
    [SerializeField] private float _spawnSpeed = 1f;
    [SerializeField] private List<GameObject> _enemyList;
    private float _spawnCooldown;
    private GameObject _currentEnemy;
    private void Start() {
        _spawnCooldown = _spawnTime;
        _currentEnemy = _enemyList[0];
    }
    private void Update()
    {
        _spawnCooldown -= _spawnSpeed * Time.deltaTime;
        if (_spawnCooldown <= 0)
        {
            int idx = Random.Range(0, _enemyList.Count);
            _currentEnemy = _enemyList[idx];
            Instantiate(_currentEnemy, transform.position + new Vector3(Random.Range(-5f, 5f), 0, 0), Quaternion.identity);
            _spawnCooldown = Random.Range(0.5f, _spawnTime);
        }
    }
}
