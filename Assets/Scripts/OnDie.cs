using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDie : MonoBehaviour
{
    public UnityEvent Death;

    void OnEnable(){
        GameStateManager.Instance.PlayerDeath += InvokeDeath;
    }

    void OnDisable(){
        GameStateManager.Instance.PlayerDeath -= InvokeDeath;
    }

    void InvokeDeath(){
        Death.Invoke();
    }
}
