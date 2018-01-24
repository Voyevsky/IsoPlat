using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateChanger : MonoBehaviour
{
    public Collider col;
    public string tag;

    void OnTriggerEnter(Collider painis)
    {
        if (painis.CompareTag(tag))
        {
            painis.SendMessageUpwards("ChangeState", 2);
        }
    }

    void OnTriggerExit(Collider painis)
    {
        if (painis.CompareTag(tag))
        {
            painis.SendMessageUpwards("ChangeState", 1);
        }
    }

	
}
