using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBehavior : MonoBehaviour
{

    public float damage;
    private Collider collid;

    private float currentAngle = 45f;
    private float readAngle = 45f;

    private Vector3 direction = Vector3.zero;

    [SerializeField] private bool isNormal;

    void Start()
    {
        collid = GetComponent<Collider>();
    }

    void FixedUpdate()
    {

        HitboxRotation();

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("TakeDamage", damage);
        }

        collid.enabled = false;

    }

    void HitboxRotation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {

            direction = GetComponentInParent<PlayerController>().direction;
            readAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Vector3 parentPos = transform.parent.position;

            transform.RotateAround(parentPos, Vector3.up, readAngle - currentAngle);

            currentAngle = readAngle;
        }
    }

}
