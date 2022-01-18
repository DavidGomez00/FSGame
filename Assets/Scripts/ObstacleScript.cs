using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    public float movementSpeed;

    private Rigidbody2D rb;
    private PlayerScript player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerScript>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Time.deltaTime * movementSpeed * -1, 0);

        if (transform.position.x <= -5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            PlayerScript player = collision.collider.gameObject.GetComponent<PlayerScript>();
            player.die();
        }
    }
}
