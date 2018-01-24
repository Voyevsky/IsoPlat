using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float life = 2.0f;

    private Vector3 projectileDirection;
    [SerializeField] private GameObject player;

    void Start()
    {
        projectileDirection = player.GetComponent<PlayerController>().direction;
    }

    void FixedUpdate()
    {
        transform.position += projectileDirection * speed;
        life -= Time.deltaTime;
        if (life < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
