using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
    [SerializeField]
    private bool isMoving = true;
    public float speed = 1f;
    int distanceMoved = 0;
    Vector3 velocity = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() {
        if(isMoving){
            if(distanceMoved == 16){
                isMoving = false;
                distanceMoved = 0;
            }
            else{
                try
                {
                    Thread.Sleep((int)(62.5-(Time.deltaTime/1000)));
                }
                catch
                {
                }
                transform.position += velocity * 0.0625f;
                distanceMoved++;
            }
        }
        else{

            if (Input.GetKeyDown(KeyCode.W) ){
                isMoving = true;

               velocity = new Vector3(0, speed);
            }
            if (Input.GetKeyDown(KeyCode.S) ){
                isMoving = true;

               velocity = new Vector3(0, -speed);
            }
            if (Input.GetKeyDown(KeyCode.A) ){
                isMoving = true;

               velocity = new Vector3(-speed, 0);
            }
            if (Input.GetKeyDown(KeyCode.D)){
                isMoving = true;

               velocity = new Vector3(speed, 0);

            }

        }
    }

}
