using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_FightSkript : MonoBehaviour
{
    private GameObject enemy;
    GameManager gameManager;
    FightManager fightManager;
    public float distance;
    
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        fightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
    }

    void Update(){
        distance = Vector2.Distance(transform.position, enemy.transform.position);
        if(distance < 1.4 && gameManager.gameState == GameState.PlayerTurn){
            if (Input.GetKeyDown(KeyCode.Space)){
                fightManager.EnemyTakeDamage(1);
            }
        }
    }
}
