using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAreaExit : MonoBehaviour
{
    public string tag;
    public GameObject[] enemiesTable;

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag(tag))
        {
            foreach (GameObject enemy in enemiesTable)
            {
                if (enemy != null)
                {
                    enemy.SendMessage("ChangeState", 1);
                }
            }
        }
    }
}
