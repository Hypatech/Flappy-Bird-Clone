using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public float scoreInterval;

    public Action PlayerDeath;
    public Action<GameObject> AsteroidDeath;

    public bool dead {get; private set;}

    void Awake(){
        Instance = this;
        Debug.Log(Instance == null);
    }

    void OnEnable(){
        PlayerDeath += StopTime;
    }

    void OnDisable(){
        PlayerDeath -= StopTime;
    }

    void StopTime(){
        StartCoroutine(StopTimeCoroutine());
    }

    IEnumerator StopTimeCoroutine(){
        var i = 0f;
        while(i < 1){
            Time.timeScale = Mathf.Lerp(1, 0, i);
            Debug.Log(i);
            i += Time.unscaledDeltaTime * 0.5f;
            yield return new WaitForEndOfFrame();
        }

        Time.timeScale = 0;
    }
}
