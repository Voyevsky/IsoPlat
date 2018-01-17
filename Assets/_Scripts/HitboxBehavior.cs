using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBehavior : MonoBehaviour
{

    public float damage;
    private Collider collid;

    private float currentAngle = 45f;

    private Vector3 direction = Vector3.zero;

    void Start()
    {
        collid = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {

            direction = GetComponentInParent<PlayerController>().direction;
            collid.enabled = false;
            Vector3 parentPos = transform.parent.position;

            transform.RotateAround(parentPos, Vector3.up, -currentAngle);

            currentAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            transform.RotateAround(parentPos, Vector3.up, currentAngle);

            //Debug.Log(currentAngle);

            //if player is attacking, set to true
            /*
            if (GetComponentInParent<PlayerController>().)
            {
                collid.enabled = true;
            }
            */

        }

        if (true)
        {

        }

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("TakeDamage", damage);
        }

        collid.enabled = false;

    }

}
