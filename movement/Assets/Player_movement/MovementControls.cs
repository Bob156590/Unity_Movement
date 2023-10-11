using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

enum GameState{
    PlayerTurn,
    PlayerMove,
    EnemyTurn,
    EnemyMove,
}
public class MovementControls : MonoBehaviour
{
    GameState gameState = GameState.PlayerTurn;
    [SerializeField]
    private bool isMoving = true;
    public float speed = 1f;
    int distanceMoved = 0;
    Vector3 velocity = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        if(gameState == GameState.PlayerTurn)
        {
            /*Process playerturn*/
            if(Input.GetKeyUp(KeyCode.LeftShift)){
                gameState = GameState.PlayerMove;
            }
        } 
        else if(gameState == GameState.PlayerMove){}
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
