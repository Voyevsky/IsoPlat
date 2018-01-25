using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerController player;

	void Start ()
    {
        player = gameObject.GetComponentInParent<PlayerController>();
	}

    void OnTriggerEnter()
    {
        player.grounded = true;
    }

    void OnTriggerStay()
    {
        player.grounded = true;
    }

    void OnTriggerExit()
    {
        player.grounded = false;
    }

}
