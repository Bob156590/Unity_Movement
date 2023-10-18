using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    [SerializeField]
    private Transform player; 
    int distanceMoved = 0;
    public float speed = 3f;
    Vector3 pteradactyl;
    GameManager gameManager;
    // Update is called once per frame
    void Start(){
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    void Update() {
        if(gameManager.gameState == GameState.EnemyTurn)
        {
            if(transform.position.x != player.position.x && Math.Abs(transform.position.x - player.position.x) != 1){
                pteradactyl = new Vector3(-(transform.position.x - player.position.x)/Math.Abs(transform.position.x - player.position.x), 0);
                gameManager.UpdateGameState(GameState.EnemyMove);
            }
            else if(transform.position.y != player.position.y && Math.Abs(transform.position.y - player.position.y) != 1){
                pteradactyl = new Vector3(0, -(transform.position.y - player.position.y)/Math.Abs(transform.position.y - player.position.y));
                gameManager.UpdateGameState(GameState.EnemyMove);                
            }
            else if(transform.position.y != player.position.y && Math.Abs(transform.position.y - player.position.y) == 1 && Math.Abs(transform.position.x - player.position.x) == 1){
                pteradactyl = new Vector3(0, -(transform.position.y - player.position.y)/Math.Abs(transform.position.y - player.position.y));
                gameManager.UpdateGameState(GameState.EnemyMove);                
            }
            else gameManager.UpdateGameState(GameState.PlayerTurn);
        }
        else if(gameManager.gameState == GameState.EnemyMove){
            if(distanceMoved == 16){
                gameManager.UpdateGameState(GameState.PlayerTurn);
                distanceMoved = 0;
            }
            else{
                transform.position += pteradactyl * 1/16f;
                distanceMoved++;
            }
        }
    }
}
