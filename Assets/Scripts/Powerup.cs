using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : Asteroid
{

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        rb.position += Vector3.left * speed * Time.fixedDeltaTime;
        rb.position += Vector3.up * Mathf.Sin(Time.time) * 0.01f;
    }

    protected override void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){ 
            GameStateManager.Instance.PowerupGrabbed?.Invoke();
            Destroy(this.gameObject);
        }
    }

}
