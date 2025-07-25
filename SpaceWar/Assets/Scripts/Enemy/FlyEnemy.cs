using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    [SerializeField] private Fire _firePrefab;
    [SerializeField] private float _delayFireTime = 0.7f;
    private float _currentDelayFireTime;
    private void Start()
    {
        _currentDelayFireTime = _delayFireTime;
    }
    private void Update()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        _firePrefab.SetCurrentCooldown(Mathf.Max(0, _firePrefab.GetCurrentCooldown() - Time.deltaTime));
        _currentDelayFireTime -= 1f * Time.deltaTime;
        if (_currentDelayFireTime <= 0)
        {
            Shot();
            _currentDelayFireTime = _delayFireTime;
        }
    }
    private void Shot()
    {
        if (_firePrefab.GetCurrentCooldown() == 0)
        {
            Instantiate(_firePrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            _firePrefab.SetCurrentCooldown(_firePrefab.GetCooldown());
            Debug.Log("Shot With: " + _firePrefab.GetCooldown());
        }
    }
}
