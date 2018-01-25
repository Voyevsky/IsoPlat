using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateChanger : MonoBehaviour
{
    //public Collider col;
    public string tag;

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.CompareTag(tag))
        {
            enemy.SendMessageUpwards("ChangeState", 3);
        }
    }

    void OnTriggerExit(Collider enemy)
    {
        if (enemy.CompareTag(tag))
        {
            enemy.SendMessageUpwards("ChangeState", 2);
        }
    }

	
}
