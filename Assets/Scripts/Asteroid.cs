using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public ScreenShake shake;
    public float speed;
    public Rigidbody rb;
    bool naturalDeath = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position += Vector3.left * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            shake.trauma += 1;
            naturalDeath = false;
            Destroy(this.gameObject);
        }
    }

    void OnDestroy(){
        if(naturalDeath){
            Debug.Log("OMG SO TRUE");
            GameStateManager.Instance.AsteroidDeath?.Invoke(gameObject);
        }
    }
}
