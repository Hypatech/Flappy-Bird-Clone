using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    public ScreenShake shake;
    public ScoreHud score;

    public float jumpSpeed, gravity, fastGravity;
    public float maxHeight;
    public Rigidbody rb;

    public Vector3 velocity;
    float curGravity;

    public bool powerup;
    float powerupEnd;

    public int health = 3;

    public GameObject nonPowerModel;
    public GameObject powerModel;

    public GameObject explodeParticle;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable(){
        GameStateManager.Instance.AsteroidDeath += TakeDamage;
        GameStateManager.Instance.PowerupGrabbed += PowerupGrab;
    }

    void OnDisable(){
        GameStateManager.Instance.AsteroidDeath -= TakeDamage;
        GameStateManager.Instance.PowerupGrabbed -= PowerupGrab;
    }

    void TakeDamage(GameObject go){
        if(powerup){
            score.score += 5;
            var pgo = GameObject.Instantiate(explodeParticle);
            pgo.transform.position = transform.position;
            Destroy(pgo, 3);
            return;
        }

        health--;
        if(health <= 0){
            shake.trauma += 3;
            this.enabled = false;
            nonPowerModel.SetActive(false);
            GameStateManager.Instance.PlayerDeath?.Invoke();
        }
    }

    void PowerupGrab(){
        if(powerup){
            score.score += 20;
        }

        powerup = true;
        powerupEnd = Time.time + 10;
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

        if(Time.time >= powerupEnd){
            powerup = false;
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
            TakeDamage(gameObject);
        }

        rb.position += velocity * Time.fixedDeltaTime;
    }
}
