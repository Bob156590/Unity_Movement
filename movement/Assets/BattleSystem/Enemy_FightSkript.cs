using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FightSkript : MonoBehaviour
{
    private GameObject player;
    GameManager gameManager;
    FightManager fightManager;
    public float distance;
    bool opportunity;
    private int enemyPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        fightManager = GameObject.FindGameObjectWithTag("FightManager").GetComponent<FightManager>();
        enemyPos = EnemiesManager.enemyHP.Count;
        EnemiesManager.enemyHP.Add(5);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 1.5 && gameManager.gameState == GameState.EnemyTurn){
            fightManager.PlayerTakeDamage(1);
            opportunity = true;
        }
        else if(distance >= 2 && opportunity && gameManager.gameState == GameState.PlayerMove){
            opportunity = false;
            fightManager.Enemyopportunity(1);
        }
        if(EnemiesManager.enemyHP[enemyPos] <= 0) 
        {
            Destroy(gameObject);
        }
    }
    public void EnemyTakeDamage(int amount){
        EnemiesManager.enemyHP[enemyPos] -= amount;
        gameManager.UpdateGameState(GameState.EnemyTurn);
    }
    private void OnDestroy() 
    {
        EnemiesManager.enemyHP[enemyPos] = null;
    }
}
