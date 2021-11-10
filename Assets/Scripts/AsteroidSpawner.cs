using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public ScreenShake shake;
    public GameObject asteroidPrefab, powerupPrefab;
    public float speedVariation;
    public float powerupChance;

    public float nextTime;
    public float interval;
    float _interval;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable(){
        _interval = interval;
        GameStateManager.Instance.AsteroidDeath += ShakeCam;
    }
    
    void OnDisable(){
        GameStateManager.Instance.AsteroidDeath -= ShakeCam;
    }

    void ShakeCam(GameObject asteroid){
        shake.trauma += 2;
    }

    // Update is called once per frame
    void Update()
    {
        _interval -= Time.deltaTime / 100;
        _interval = Mathf.Max(0.25f, _interval);

        if(Time.time > nextTime){
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid(){

        nextTime = Time.time + Random.Range(0, _interval);  

        var shouldPowerup = Random.Range(0, 100) < powerupChance;
        if(shouldPowerup){
            SpawnFakeAsteroid();
        } else{
            SpawnRealAsteroid();
        }
    }

    void SpawnRealAsteroid(){
        var go = Instantiate(asteroidPrefab);
        go.transform.position = transform.position;
        go.transform.position += Vector3.up * Random.Range(-5.5f, 6f);

             
        var related = Random.Range(-speedVariation, speedVariation);
        go.GetComponent<Asteroid>().speed += related * (interval / _interval);
        go.transform.localScale = Vector3.one - (Vector3.one * related / speedVariation) * 0.55f;


        Destroy(go, 6);
    }

    void SpawnFakeAsteroid(){
        var go = Instantiate(powerupPrefab);
        go.transform.position = transform.position;
        go.transform.position += Vector3.up * Random.Range(-5.5f, 6f);
        Destroy(go, 7);

        go.GetComponent<Powerup>().speed = 8;
    }
}
