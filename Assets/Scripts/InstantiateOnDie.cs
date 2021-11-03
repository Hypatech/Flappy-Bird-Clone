using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstantiateOnDie : MonoBehaviour
{
    public GameObject prefab;

    void OnEnable(){
        GameStateManager.Instance.PlayerDeath += InvokeDeath;
    }

    void OnDisable(){
        GameStateManager.Instance.PlayerDeath -= InvokeDeath;
    }

    void InvokeDeath(){
        var go = GameObject.Instantiate(prefab);
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation; 
    }
}
