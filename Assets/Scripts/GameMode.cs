using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

using watdowedonow;


public class GameMode : MonoBehaviour {

    public enum GameType { Struggle = 0, };
    public GameType currentGameMode = GameType.Struggle;
    public Game game;
    public void GiveWinner()
    {
        switch (currentGameMode)
        {
            case GameType.Struggle:
                Dictionary<int,GameObject> playerStats = new Dictionary<int, GameObject>();
                GameObject[] players  = GameObject.FindGameObjectsWithTag("Player");
                GameObject closest;
                foreach (GameObject player in players)
                {
                    playerStats.Add(player.GetComponent<PlayerStats>().kills,player);
                }
                List<int> keyList = playerStats.Keys.ToList();
                keyList.Sort();
                
                GameObject winner = playerStats[keyList.Last()];
                
                print("Winner is Player: "+ winner.name+" with "+keyList.Last()+" Kills");
                switchGameMode();
                break;
        }    


    }

    void switchGameMode()
    {
        currentGameMode = GameType.Struggle;
        game.SECONDS_LEFT = 15;
        game.showResult = true;
    }

}
