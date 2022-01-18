using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{

    private bool spawnNext;

    // Start is called before the first frame update
    void Start()
    {
        spawnNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * 0.01f;

        if (transform.position.x <= -9 && !spawnNext)
        {
            Instantiate(this, new Vector3(23.94f, transform.position.y, transform.position.z), Quaternion.identity);
            spawnNext = true;
        }

        if(transform.position.x <= -20)
        {
            Destroy(this.gameObject);
        }

    }
}
