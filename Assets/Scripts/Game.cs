using System;
using System.Collections.Generic;
using UnityEngine;

namespace watdowedonow
{
    public class Game : MonoBehaviour
    {
        public NetworkHandler Network;
        public Dictionary<int, NetworkPlayer> CurrentlyConnectedPlayer;

        void Start()
        {
            Network.OnBytesReceived += OnBytesReceived;
        }

        void OnBytesReceived(int id, string name, byte action)
        {
            MovePlayer(GetPlayer(id, name), action);
        }

        private void MovePlayer(NetworkPlayer player, byte action)
        {
            Debug.Log("move player: " + (Direction) Convert.ToInt32(action));
            player.character.OnKeydown((Direction) Convert.ToInt32(action));
        }
        
        private NetworkPlayer GetPlayer(int id, string s)
        {
            return CurrentlyConnectedPlayer.ContainsKey(id) ? CurrentlyConnectedPlayer[id] : SpawnIfNotExists(id, name);
        }

        private NetworkPlayer SpawnIfNotExists(int id, string name)
        {
            var character = Prefabs.Shared.Character.Instantiate();
            Debug.Log("spawn " + id + " name " + name);
            return null;
        }

        void Update()
        {

        }
    }
}