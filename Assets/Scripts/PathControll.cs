using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class PathControll : MonoBehaviour {
    
    public int id;
    public PathNode[] pathNodes;
    // Use this for initialization
    public IEnumerator<PathNode> GetPathEnumerator() {
        if (pathNodes == null || pathNodes.Length < 1)
            yield break;
        var direction = 1;
        var index = 0;
        while (true)
        {
            yield return pathNodes[index];
            if (pathNodes.Length == 1)
                continue;
            
            if(index <= 0)
                direction = 1;
            else if (index >= pathNodes.Length -1)
                direction = -1;
            
            index = index + direction;
        }
        
    }
    
    // Update is called once per frame
    public void OnDrawGizmos()
    {
        if (pathNodes == null || pathNodes.Length < 2)
            return;
        var pathPoints = pathNodes.Where(t => t != null).ToList();
        if (pathPoints.Count < 2)
            return;
        
        for (int i = 1; i < pathNodes.Length; i++)
        {
            Gizmos.DrawLine(pathNodes[i - 1].transform.position, pathNodes[i].transform.position);
        }        
    }
}
