using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public NetworkHandler network;

	void Start ()
	{
	    network.OnConnect += OnConnect;

	}

    void OnConnect(int id, string name, byte action)
    {
        
    }
	
	void Update () {
	
	}
}
