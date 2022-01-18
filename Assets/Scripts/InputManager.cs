using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public bool jumpKeyboard { get; private set; }
    public bool jumpAndroid { get; private set; }

    private bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        jumpKeyboard = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        jumpKeyboard = Input.GetKeyDown(KeyCode.Space);

        if (Input.touchCount > 0 && canJump)
        {
            jumpAndroid = true;
            canJump = false;
        }
        else if (Input.touchCount <= 0 && !canJump)
        {
            canJump = true;
            jumpAndroid = false;
        }else if (Input.touchCount > 0 && !canJump)
        {
            jumpAndroid = false;
        }
        
    }
}
