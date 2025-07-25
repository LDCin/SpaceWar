using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Fire
{
    private void Update()
    {
        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        _existTime -= _existTime * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Enemy oponent = collision.gameObject.GetComponent<Enemy>();
            oponent.TakeDamage(_damage);
            Debug.Log("Enemy Is Hit!");
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
