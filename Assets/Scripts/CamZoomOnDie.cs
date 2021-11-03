using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomOnDie : MonoBehaviour
{
    float startFov;
    Camera c;

    public float zoomFov;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Camera>();
        startFov = c.fieldOfView;
    }

    void OnEnable(){
        GameStateManager.Instance.PlayerDeath += StartZoom;
    }

    void OnDisable(){
        GameStateManager.Instance.PlayerDeath -= StartZoom;
    }

    void StartZoom(){
        StartCoroutine(ZoomRoutine());
    }

    IEnumerator ZoomRoutine(){
        var targForward = (PlayerControl.Instance.transform.position - transform.position).normalized;;
        var i = 0f;
        while(i < 1){
            c.fieldOfView = Mathf.Lerp(startFov, zoomFov, i);
            transform.forward = Vector3.Lerp(transform.forward, targForward, i);
            i += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        c.fieldOfView = zoomFov;
    }
}
