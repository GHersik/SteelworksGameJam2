using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates{
        Played,
        Finished
    }

    public GameStates gameState = GameStates.Played;

    public void LoseGame(){
        gameState = GameStates.Finished;
        //GameLost.Instance.ShowPanel();
    }
}
