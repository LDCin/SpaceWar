using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour, IDamagable
{
    protected Rigidbody2D _rb;
    [SerializeField] protected List<Fire> _firePrefabList = new List<Fire>();
    [SerializeField] protected Fire _firePrefab;
    [SerializeField] protected float _moveSpeed = 1.5f;
    [SerializeField] protected int _damage = 1;
    protected int _healthPoint = 5;
    protected int _currentHealthPoint;
    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _firePrefab = _firePrefabList[0];
        _currentHealthPoint = _healthPoint;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(enemy.GetDamage());
        }
    }
    public void TakeDamage(int enemyDamage)
    {
        _currentHealthPoint -= enemyDamage;
        if (_currentHealthPoint <= 0)
        {
            GameManager.instance.GameOver();
            Debug.Log("Game Over!");
        }
    }
}
