using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePoint : MonoBehaviour
{

    private bool pointGiven;

    private void Start()
    {
        pointGiven = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x < 2 && !pointGiven)
        {
            FindObjectOfType<PointsManager>().addPoint();
            pointGiven = true;
        }
    }
}
