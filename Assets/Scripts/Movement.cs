using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

[RequireComponent(typeof(InputManager))]
public class Movement : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator animator;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inputManager.jumpKeyboard || inputManager.jumpAndroid)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetFloat("YVelocity", rb.velocity.y);
    }
}
