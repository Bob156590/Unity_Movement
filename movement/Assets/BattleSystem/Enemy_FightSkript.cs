using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FightSkript : Battle
{
    private GameObject player;
    GameManager gameManager;
    public float distance;
    public Enemy_FightSkript(int hp) : base(hp){
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < 1.5 && gameManager.gameState == GameState.PlayerTurn){}
    }
    public override void TakeDamage(int amount){
        hp -= amount;
    }
}
