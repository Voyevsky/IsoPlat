using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public float life = 3, speed = 0.5f;
    public float damageDealt = 30f;

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
