using UnityEngine;

public class Prefabs : MonoBehaviour
{
    #region Singleton

    private static volatile Prefabs _instance;
    private static readonly object SyncRoot = new Object();

    public static Prefabs Shared
    {
        get
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    return _instance ?? (_instance = ((GameObject) Resources.Load("Prefabs", typeof (GameObject))).GetComponent<Prefabs>());
                }
            }

            return _instance;
        }
    }

    #endregion

    public GameObject Character;
    public GameObject Splash;
}
