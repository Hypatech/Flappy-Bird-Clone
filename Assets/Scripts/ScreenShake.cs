using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float trauma, traumaRecovery;
    public float traumaSpeed;
    public Vector3 origPos;

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var mappedPerlin = Mathf.PerlinNoise(Time.time * traumaSpeed, Time.time * traumaSpeed);
        var traumaPow = trauma * trauma * mappedPerlin;

        transform.position = origPos + new Vector3(traumaPow, traumaPow);
        trauma = Mathf.Lerp(trauma, 0, 3 * Time.deltaTime);
    }
}
