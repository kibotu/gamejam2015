using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraController : MonoBehaviour {

        

    public float ShakeIntensity = 0.005f;    
    public float ShackTime;

    private float time;
    private Vector3 pos;
    private Quaternion originRot;
    public PathControll path;
    private IEnumerator<PathNode> currentPathNode;
    public float speed = 1;
    public float maxDistanceToPoint = .1f;
    private float t = 0f;
    private Vector3 lastPos;

    void Start()
        {
            originRot = transform.rotation;
            pos = transform.position;
       
            currentPathNode = path.GetPathEnumerator();
            currentPathNode.MoveNext();
           
            if (currentPathNode.Current == null)
                return;
            transform.position = currentPathNode.Current.transform.position;
            lastPos = currentPathNode.Current.transform.position;
            currentPathNode.MoveNext();
        }

        void Update () 
        {
            transform.position = Vector3.Lerp(lastPos, currentPathNode.Current.transform.position, t);
            
            t += Time.deltaTime * speed;
            if (t >= 1.0f) {
                t = 0.0f;
                lastPos = currentPathNode.Current.transform.position;
                currentPathNode.MoveNext();
            }
            
            /*if(time > 0)
            {
                //transform.position = pos + Random.insideUnitSphere * ShakeIntensity;
                //transform.rotation = new Quaternion(originRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
                 //                               originRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
                  //                              originRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
                    //                            originRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f);
                time--;                
            }
            else 
            {
                //transform.position = pos;
                //transform.rotation = originRot;
            }*/
        }

        public void DoShake()
        {
            time = ShackTime;
        }    
        
        
    }

