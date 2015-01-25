using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class GameMode : MonoBehaviour {

    public void GiveWinner()
    {
        //GameObejct[] players = GameObject.FindGameObjectsWithTag("Player");
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
    }
}
