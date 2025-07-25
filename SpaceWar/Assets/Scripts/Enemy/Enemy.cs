using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] protected float _moveSpeed = 2f;
    [SerializeField] private int _healthPoint = 5;
    [SerializeField] private int damage = 1;
    private int _currentHealthPoint;
    private void Start()
    {
        _currentHealthPoint = _healthPoint;
    }
    public int GetDamage()
    {
        return damage;
    }
    public void TakeDamage(int playerDamage)
    {
        _currentHealthPoint -= playerDamage;
        if (_currentHealthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MapLimit"))
        {
            Destroy(gameObject);
        }
    }
}
