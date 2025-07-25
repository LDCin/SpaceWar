using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : Fire
{
    private void Update()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        _existTime -= _existTime * Time.deltaTime;
        if (_existTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerShip oponent = collision.gameObject.GetComponent<PlayerShip>();
            oponent.TakeDamage(_damage);
            Debug.Log("Player Is Hit!");
        }
    }
}
