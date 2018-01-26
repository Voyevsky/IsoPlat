using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEBehavior : MonoBehaviour
{
    [SerializeField] private float life = 2;
    [SerializeField] private float damageDealt = 30;
    [SerializeField] private float speed = 0.05f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed);
        life -= Time.deltaTime;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("FlyingEnemy"))
        {
            col.SendMessageUpwards("TakeDamage", damageDealt);
        }
    }
}
