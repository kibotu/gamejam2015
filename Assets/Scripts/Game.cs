using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using whatdowedonow;

namespace watdowedonow
{
    public class Game : MonoBehaviour
    {
        public static volatile Dictionary<int, Character> CurrentlyConnectedPlayer;

        public NetworkController network;
        private GameMode gameMode;
		public float SECONDS_LEFT;
		public Text TimeLeftText;
        public bool showResult = true;

        void Awake()
        {
            gameMode = GetComponent<GameMode>();
            CurrentlyConnectedPlayer = new Dictionary<int, Character>();
        }

        void Start()
        {
            network.OnBytesReceived += OnBytesReceived;
            Sounds.Shared.KickSomeAssBG.Instantiate().GetComponent<AudioSource>().Play();
        }

        void OnBytesReceived(int id, string name, byte action)
        {
            // receive async network call
            ExecuteOnMainThread.Schedule.Enqueue(() => MovePlayer(GetPlayer(id, name), action));
        }

        private void MovePlayer(Character player, byte action)
        {
            Debug.Log("move player: " + (Direction) Convert.ToInt32(action));
            player.OnKeydown((Direction)Convert.ToInt32(action));
        }

        private Character GetPlayer(int id, string playerName)
        {
            return CurrentlyConnectedPlayer.ContainsKey(id) ? CurrentlyConnectedPlayer[id] : SpawnIfNotExists(id, playerName);
        }

        private Character SpawnIfNotExists(int id, string playerName)
        {
            Debug.Log("spawn " + id + " name " + playerName);
            var go = Prefabs.Shared.Character.Instantiate();
			go.GetComponentInChildren<Text> ().text = playerName;
            go.name = playerName;
            var character = go.GetComponent<Character>();
            character.id = id;
            CurrentlyConnectedPlayer[id] = character;
            return character;
        }

        void Update()
        {
			SECONDS_LEFT -= Time.deltaTime;

			double secondsLeft = Math.Round (SECONDS_LEFT);
			string timeLeft = TimeSpan.FromSeconds (secondsLeft).ToString();
			TimeLeftText.text = timeLeft.Substring(4, timeLeft.Length - 4);

			if (SECONDS_LEFT <= 0.3f) {

                if(showResult){
                    showResult = false;
                    gameMode.GiveWinner();
					var winSound = Sounds.Shared.Win.Instantiate().GetComponent<AudioSource>();
					winSound.Play();
                }

			}
        }
    }
}