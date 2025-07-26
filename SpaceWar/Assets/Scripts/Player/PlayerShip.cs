using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : SpaceShip
{
    private void Update()
    {
        _firePrefab.SetCurrentCooldown(Mathf.Max(0, _firePrefab.GetCurrentCooldown() - Time.deltaTime));
        Fly();
        ChangeWeapon();
        Shot();
    }
    private void Fly()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += Vector3.up;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.down;
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
        if (direction != Vector3.zero)
        {
            transform.Translate(direction.normalized * _moveSpeed * Time.deltaTime);
        }
    }
    private void Shot()
    {
        if (Input.GetKey(KeyCode.J) && _firePrefab.GetCurrentCooldown() == 0)
        {
            Instantiate(_firePrefab, transform.position + new Vector3(0, 0.45f, 0), Quaternion.identity);
            _firePrefab.SetCurrentCooldown(_firePrefab.GetCooldown());
            _firePrefab.SetCurrentQuantity(_firePrefab.GetCurrentQuantity() - 1);
            Debug.Log("Shot With: " + _firePrefab.GetCooldown());
        }
    }
    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            int idx = _firePrefabList.IndexOf(_firePrefab);
            if (idx == _firePrefabList.Count - 1) idx = 0;
            else idx++;
            _firePrefab = _firePrefabList[idx];
            // _fire = _firePrefab;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }
}