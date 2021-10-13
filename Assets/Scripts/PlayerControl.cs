using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpSpeed, gravity, fastGravity;
    public float maxHeight;
    public Rigidbody rb;

    public Vector3 velocity;
    float curGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            velocity = Vector3.up * jumpSpeed;
        }

        if(Input.GetKey(KeyCode.S)){
            curGravity = fastGravity;
        } else{
            curGravity = gravity;
        }
    }

    void FixedUpdate(){
        velocity -= Vector3.up * curGravity * Time.fixedDeltaTime;

        if(rb.position.y > maxHeight){
            rb.position = Vector3.up * maxHeight;
        }

        if(rb.position.y < -maxHeight){
            
        }

        rb.position += velocity * Time.fixedDeltaTime;
    }

    
}
