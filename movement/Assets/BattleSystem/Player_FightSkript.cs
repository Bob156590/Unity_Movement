using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_FightSkript : Battle
{
    private GameObject enemy;
    GameManager gameManager;
    public float distance;
    public Player_FightSkript(int hp) : base(hp){
        hp = 5;
    }
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update(){
        distance = Vector2.Distance(transform.position, enemy.transform.position);
        if(distance < 1.5 && gameManager.gameState == GameState.PlayerTurn){
            if (Input.GetKeyDown(KeyCode.Space)){
                DealDamage(1);
            }
        }
    }
    public void DealDamage(int amount){
        Enemy_FightSkript damge = new Enemy_FightSkript(3);
        damge.TakeDamage(1);
    }

    public override void TakeDamage(int amount){
        hp -= amount;
    }
}
