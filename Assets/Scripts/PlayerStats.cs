using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public delegate void StatsUpdatedDelegate ();
	public event StatsUpdatedDelegate OnStatsUpdated;

    private int kills = 0;
	public int Kills {
		get {
			return kills;
		}
		set {
			kills = value;
			if (OnStatsUpdated != null) OnStatsUpdated();
		}

	}


	private int deaths = 0;
	public int Deaths {
		get {
			return deaths;
		}
		set {
			deaths = value;
			if (OnStatsUpdated != null) OnStatsUpdated();
		}
		
	}


    public int karma = 0;
	
}
