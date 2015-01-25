using UnityEngine;
using System.Collections;

public class ObstacleTrigger : MonoBehaviour {


    public enum Obstacle { puddle = 0, };
    public float slow = 5;
    public Obstacle thisObstacle = Obstacle.puddle;
    
   
    
    
    void OnTriggerStay2D(Collider2D collider)
    {        
        if(collider.gameObject.CompareTag("PlayerFeet"))
        {
            switch (thisObstacle)
            {
                case Obstacle.puddle:
                    collider.transform.parent.parent.GetComponent<Character>().speed = slow;
                    break;
            }          

        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("PlayerFeet"))
        {
        switch (thisObstacle)
        {
            case Obstacle.puddle:
                collider.transform.parent.parent.GetComponent<Character>().speed = collider.transform.parent.parent.GetComponent<Character>().normalSpeed;
                break;
        }  
        }
    }

}
