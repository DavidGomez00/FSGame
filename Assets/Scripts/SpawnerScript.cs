using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public float maxRango;
    public float minRango;

    public float waitTime;

    public GameObject obstaculo;

    private bool canSpawn;

    private void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;

            float randomY = Random.Range(minRango, maxRango);

            Instantiate(obstaculo, new Vector2(transform.position.x, randomY), Quaternion.identity);

            StartCoroutine("Dlay");
        }
    }

    IEnumerator Dlay()
    {
        yield return new WaitForSeconds(waitTime);

        canSpawn = true;
    }

}
