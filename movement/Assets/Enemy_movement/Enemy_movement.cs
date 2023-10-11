using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    private Transform playerTransform; 
    int distanceMoved = 0;
    public float speed = 3f;
    // Update is called once per frame
    void Start(){
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update() {
        /*https://learn.unity.com/tutorial/unit-mechanics?uv=5.x&projectId=5c514a00edbc2a0020694718#5c7f8528edbc2a002053b6f4*/
    }
}
