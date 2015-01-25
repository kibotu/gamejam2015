using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class HighscoreController : MonoBehaviour {

	public Text ScorePlayer1;
	public Text ScorePlayer2;
	public Text ScorePlayer3;
	public Text ScorePlayer4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void UpdateInterface(List<int> sortedKeys, Dictionary<int,GameObject> players) {
		sortedKeys.Reverse ();

		if (sortedKeys.Count > 0)
			ScorePlayer1.text = players[sortedKeys[0]].GetComponent<Character>().PlayerNameText.text + " " + players[sortedKeys[0]].GetComponent<Character>().playerStats.Kills + "/" + players[sortedKeys[0]].GetComponent<Character>().playerStats.Deaths;
		if (sortedKeys.Count > 1)
			ScorePlayer2.text = players[sortedKeys[1]].GetComponent<Character>().PlayerNameText.text + " " + players[sortedKeys[1]].GetComponent<Character>().playerStats.Kills + "/" + players[sortedKeys[1]].GetComponent<Character>().playerStats.Deaths;
		if (sortedKeys.Count > 2)
			ScorePlayer3.text = players[sortedKeys[2]].GetComponent<Character>().PlayerNameText.text + " " + players[sortedKeys[2]].GetComponent<Character>().playerStats.Kills + "/" + players[sortedKeys[2]].GetComponent<Character>().playerStats.Deaths;
		if (sortedKeys.Count > 3)
			ScorePlayer4.text = players[sortedKeys[3]].GetComponent<Character>().PlayerNameText.text + " " + players[sortedKeys[3]].GetComponent<Character>().playerStats.Kills + "/" + players[sortedKeys[3]].GetComponent<Character>().playerStats.Deaths;
	}
}
