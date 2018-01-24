using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour
{
    [SerializeField] private float maxAngle = 20f;

    private float currentRotation = 0f, destinationAngle;
    //rotate head slightly towards left, then to the right
    //sine?
    //sine(time) * maxAngle

    /*
        -set currentangle to 0
        -newAngle - currentAngle
        -add this to rotation
        -currentAngle = newAngle
    */

    void Update ()
    {
        destinationAngle = Mathf.Sin(Time.fixedTime * 2) * maxAngle;
        transform.Rotate(0f, 0f, destinationAngle - currentRotation);
        currentRotation = destinationAngle;
	}



}
