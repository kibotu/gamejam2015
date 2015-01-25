using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    #region Singleton

    private static volatile Sounds _instance;
    private static readonly object SyncRoot = new Object();

    public static Sounds Shared
    {
        get
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    return _instance ?? (_instance = ((GameObject)Resources.Load("Sounds", typeof(GameObject))).GetComponent<Sounds>());
                }
            }

            return _instance;
        }
    }

    #endregion

    public GameObject AttackHit;
    public GameObject AttackMiss;
    public GameObject AttackObstacleMetal;
    public GameObject KickSomeAssBG;
    public GameObject StartButton;
    public GameObject TrollGroan;
	public GameObject TrollDie;
	public GameObject Win;
}
