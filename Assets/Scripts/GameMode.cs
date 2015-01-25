using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

using watdowedonow;


public class GameMode : MonoBehaviour {

    public enum GameType { Struggle = 0, Colors = 1 };
    public GameType currentGameMode = GameType.Struggle;
    public Game game;
    public GameObject[] colorPuddles;
    public GameObject[] colorPosistions;
    public float colorChangeTime = 5;

    public Obstacle activeColor = Obstacle.red;
    

    public void GiveWinner()
    {
        switch (currentGameMode)
        {
            case GameType.Struggle:
                Dictionary<int,GameObject> playerStats = new Dictionary<int, GameObject>();
                GameObject[] players  = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject player in players)
                {
                     if(!playerStats.ContainsKey(player.GetComponent<PlayerStats>().Kills))
                         playerStats.Add(player.GetComponent<PlayerStats>().Kills,player);
                }
                List<int> keyList = playerStats.Keys.ToList();
                keyList.Sort();
                
                GameObject winner = playerStats[keyList.Last()];
                
                print("Winner is Player: "+ winner.name+" with "+keyList.Last()+" Kills");
                switchGameMode();
                break;
            case GameType.Colors:
                Dictionary<int,GameObject> playerStat = new Dictionary<int, GameObject>();
                GameObject[] playerss  = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject player in playerss)
                {
                    playerStat.Add(player.GetComponent<PlayerStats>().karma,player);
                }
                List<int> keyListt = playerStat.Keys.ToList();
                keyListt.Sort();
                
                GameObject winnner = playerStat[keyListt.Last()];
                
                print("Winner is Player: "+ winnner.name+" with "+keyListt.Last()+" Karma");
                switchGameMode();
                break;

        }    


    }

    IEnumerator ColorGame()
    {
        activeColor = Obstacle.red;
        colorPuddles[0].transform.position = colorPosistions[0].transform.position; 
        colorPuddles[1].transform.position = colorPosistions[1].transform.position;; 
        colorPuddles[2].transform.position = colorPosistions[2].transform.position;; 
      
        yield return new WaitForSeconds(colorChangeTime);

        activeColor = Obstacle.blue;
        colorPuddles[0].transform.position = colorPosistions[1].transform.position;; 
        colorPuddles[1].transform.position = colorPosistions[0].transform.position;; 
        colorPuddles[2].transform.position = colorPosistions[2].transform.position;; 

        yield return new WaitForSeconds(colorChangeTime);

        activeColor = Obstacle.red;
        colorPuddles[0].transform.position = colorPosistions[2].transform.position;; 
        colorPuddles[1].transform.position = colorPosistions[1].transform.position;; 
        colorPuddles[2].transform.position = colorPosistions[0].transform.position;; 

    }

    void switchGameMode()
    {
        if((int)currentGameMode == (int)GameType.Struggle){
            currentGameMode = GameType.Colors;
            StartCoroutine(ColorGame());
            game.SECONDS_LEFT = 15;
            game.showResult = true;
        }else{
            currentGameMode = GameType.Struggle;
            colorPuddles[0].transform.position = new Vector3 (-200,0,0); 
            colorPuddles[1].transform.position =  new Vector3 (-200,0,0); 
            colorPuddles[2].transform.position =  new Vector3 (-200,0,0); 
        }

    }

}
