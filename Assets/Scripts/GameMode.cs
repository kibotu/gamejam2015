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
		Dictionary<int,GameObject> playerStats = new Dictionary<int, GameObject>();
		GameObject[] players  = GameObject.FindGameObjectsWithTag("Player");

        switch (currentGameMode)
        {
            case GameType.Struggle:
                foreach (GameObject player in players)
                {
                     if(!playerStats.ContainsKey(player.GetComponent<PlayerStats>().Kills))
                         playerStats.Add(player.GetComponent<PlayerStats>().Kills,player);
                }
                List<int> keyList = playerStats.Keys.ToList();
                keyList.Sort();
                
                GameObject winner = playerStats[keyList.Last()];
                
                print("1. Winner is Player: "+ winner.name+" with "+keyList.Last()+" Kills");
                switchGameMode();
                break;
            case GameType.Colors:
				foreach (GameObject player in players)
				{
					if(!playerStats.ContainsKey(player.GetComponent<PlayerStats>().Kills))
						playerStats.Add(player.GetComponent<PlayerStats>().Kills,player);
				}
				List<int> keyListColors = playerStats.Keys.ToList();
				keyListColors.Sort();
				
				GameObject winnerNew = playerStats[keyListColors.Last()];

				print("2. Winner is Player: "+ winnerNew.name+" with "+keyListColors.Last()+" Karma");
                //switchGameMode();
				game.HighscoreGroup.SetActive(true);
				game.HighscoreGroup.GetComponent<HighscoreController>().UpdateInterface(keyListColors, playerStats);
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
            game.SECONDS_LEFT = 30;
            game.showResult = true;
        }else{
            currentGameMode = GameType.Struggle;
            colorPuddles[0].transform.position = new Vector3 (-200,0,0); 
            colorPuddles[1].transform.position =  new Vector3 (-200,0,0); 
            colorPuddles[2].transform.position =  new Vector3 (-200,0,0); 
        }

    }

}
