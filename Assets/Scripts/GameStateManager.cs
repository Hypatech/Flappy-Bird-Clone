using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public float scoreInterval;

    public Action PlayerDied;
    public Action<GameObject> AsteroidDeath;

    public bool dead {get; private set;}

    void Awake(){
        Instance = this;
        Debug.Log(Instance == null);
    }
}
