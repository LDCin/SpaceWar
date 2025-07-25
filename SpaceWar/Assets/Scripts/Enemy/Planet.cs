using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Enemy
{
    private void Update()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MapLimit"))
        {
            Destroy(gameObject);
        }
    }
}
