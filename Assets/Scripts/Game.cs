using System;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

namespace watdowedonow
{
    public class Game : MonoBehaviour
    {
        public Dictionary<int, Character> CurrentlyConnectedPlayer;

        public NetworkController network;

        void Start()
        {
            network.OnBytesReceived += OnBytesReceived;
        }

        void OnBytesReceived(int id, string name, byte action)
        {
            MovePlayer(GetPlayer(id, name), action);
        }

        private void MovePlayer(Character player, byte action)
        {
            Debug.Log("move player: " + (Direction) Convert.ToInt32(action));
            player.OnKeydown((Direction)Convert.ToInt32(action));
        }

        private Character GetPlayer(int id, string s)
        {
            return CurrentlyConnectedPlayer.ContainsKey(id) ? CurrentlyConnectedPlayer[id] : SpawnIfNotExists(id, name);
        }

        private Character SpawnIfNotExists(int id, string name)
        {
            Debug.Log("spawn " + id + " name " + name);
            var go = Prefabs.Shared.Character.Instantiate();
            var character = go.GetComponent<Character>();
            CurrentlyConnectedPlayer[id] = character;
            return character;
        }

        void Update()
        {

        }
    }
}