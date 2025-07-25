using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 1.5f;
    [SerializeField] protected int _damage = 1;
    [SerializeField] protected float _cooldown = 2f;
    [SerializeField] protected int _quantity = 100;
    protected float _existTime = 5f;
    protected float _currentCooldown = 0;
    protected int _currentQuantity = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Enemy oponent = collision.gameObject.GetComponent<Enemy>();
            oponent.TakeDamage(_damage);
            Debug.Log("Hit!");
        }
    }
    public float GetCurrentCooldown()
    {
        return _currentCooldown;
    }
    public void SetCurrentCooldown(float newCooldown)
    {
        _currentCooldown = newCooldown;
    }
    public float GetCooldown()
    {
        return _cooldown;
    }
    public int GetCurrentQuantity()
    {
        return _quantity;
    }
    public void SetCurrentQuantity(int newQuantity)
    {
        _currentQuantity = newQuantity;
    }
}
