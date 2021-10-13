using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public ScreenShake shake;
    public GameObject asteroidPrefab;
    public float speedVariation;

    public float nextTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextTime){
            nextTime = Time.time + Random.Range(0, 2);   
            var go = Instantiate(asteroidPrefab);
            go.transform.position += Vector3.up * Random.Range(-5, 5);
            go.GetComponent<Asteroid>().speed += Random.Range(-speedVariation, speedVariation);
            go.GetComponent<Asteroid>().shake = shake;
            Destroy(go, 10);
        }
    }
}
