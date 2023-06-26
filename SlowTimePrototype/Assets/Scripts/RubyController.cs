using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class RubyController : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float jumpForce = 250f;
    Rigidbody2D RubyRigidbody;
    float hAxis;
    bool IsJumping;
    public PlatformController PlatformController;
    public float PlatformSpeed;
    public float DebugNum;
    
    // Start is called before the first frame update
    void Start()
    {
       
        RubyRigidbody = GetComponent<Rigidbody2D>();
        PlatformController = GetComponent<PlatformController>();
        PlatformSpeed = PlatformController.speed;
        DebugNum = PlatformController.debugNumber;
        IsJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");
        RubyRigidbody.velocity = new Vector2(10 * hAxis, RubyRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsJumping == false)
        {
            RubyRigidbody.AddForce(Vector2.up * jumpForce);
        }

        if (IsJumping == true)
        {
            EnableTimeSlow();
        }
        
    }

    void OnCollisionExit2D(Collision2D other)
    {
        IsJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsJumping = false;
    }

    private void EnableTimeSlow()
    {
        if (Input.GetKeyDown (KeyCode.LeftShift))
        {
            PlatformSpeed = PlatformSpeed * 0.1f;
            DebugNum++;
            Debug.Log(PlatformController.debugNumber);
            
        }
    }

}
