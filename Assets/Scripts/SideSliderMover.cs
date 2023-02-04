using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSliderMover : MonoBehaviour
{
    public float time = 2.0f;

    void Update () 
    {
        Vector3 startPoint = new Vector3 (0, 0, 0);
        Vector3 endPoint = new Vector3 (0, 0, 3);
        transform.position = Vector3.Lerp (startPoint, endPoint, time);
    }
}
