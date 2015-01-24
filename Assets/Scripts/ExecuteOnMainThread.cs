using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace whatdowedonow
{
    public  class ExecuteOnMainThread : MonoBehaviour
    {
        public readonly static Queue<Action> Schedule = new Queue<Action>();

        void Update()
        {
            // dispatch stuff on main thread
            while (Schedule.Count > 0)
            {
                Schedule.Dequeue().Invoke();
            }
        }
    }
}
