using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    static GameManager gameManager;
    public static void SetState()
    {
        foreach(bool? i in enemyMoved)
        {
            if(i != null && i.Value) return;
        }
        gameManager.UpdateGameState(GameState.PlayerTurn);
        for(int i = 0; i < enemyMoved.Count; i++){
            if(enemyMoved[i] != null)
                enemyMoved[i] = true;
        }
    }
    public static List<float?> enemyHP = new List<float?>();
    public static List<bool?> enemyMoved = new List<bool?>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
