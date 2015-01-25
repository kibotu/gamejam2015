using UnityEngine;
using System.Collections;

public class ObstacleTrigger : MonoBehaviour {


    public enum Obstacle { puddle = 0, drug = 1,};
    public float slow = 5;

    public float drugTime = 10;

    public Obstacle thisObstacle = Obstacle.puddle;
    public GameObject camera;
    public GameObject drugCamera;
   
    
    
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
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("PlayerFeet"))
        {
            switch (thisObstacle)
            {

                case Obstacle.drug:
                    StartCoroutine(Trip());
                    break;
            }          
            
        }
    }

    IEnumerator Trip()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject[] players  = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.GetComponent<Character>().dontInvert = false;
        }
        drugCamera.SetActive(true);
        camera.SetActive(false);
        yield return new WaitForSeconds(drugTime);
        camera.SetActive(true);
        drugCamera.SetActive(false);
        foreach (GameObject player in players)
        {
            player.GetComponent<Character>().dontInvert = true;
            
            
        }
        Destroy(gameObject);
    }

}
