using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    public ScreenShake shake;

    public float jumpSpeed, gravity, fastGravity;
    public float maxHeight;
    public Rigidbody rb;

    public Vector3 velocity;
    float curGravity;

    public bool powerup;

    public int health = 3;

    public GameObject nonPowerModel;
    public GameObject powerModel;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable(){
        GameStateManager.Instance.AsteroidDeath += TakeDamage;
    }

    void OnDisable(){
        GameStateManager.Instance.AsteroidDeath -= TakeDamage;
    }

    void TakeDamage(GameObject go){
        health--;
        if(health <= 0){
            shake.trauma += 2;
            this.enabled = false;
            nonPowerModel.SetActive(false);
            GameStateManager.Instance.PlayerDeath?.Invoke();
        }
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

        powerModel.SetActive(powerup);
        nonPowerModel.SetActive(!powerup);
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
