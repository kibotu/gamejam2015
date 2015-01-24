using System;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using whatdowedonow;

namespace watdowedonow
{
    public class Game : MonoBehaviour
    {
        public static volatile Dictionary<int, Character> CurrentlyConnectedPlayer;

        public NetworkController network;

        void Awake()
        {
            CurrentlyConnectedPlayer = new Dictionary<int, Character>();
        }

        void Start()
        {
            network.OnBytesReceived += OnBytesReceived;
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
            go.name = playerName;
            var character = go.GetComponent<Character>();
            character.id = id;
            CurrentlyConnectedPlayer[id] = character;
            return character;
        }

        void Update()
        {

        }
    }
}