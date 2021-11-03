using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

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
            GameStateManager.Instance.AsteroidDeath?.Invoke(gameObject);
            Destroy(this.gameObject);
        }
    }

}
