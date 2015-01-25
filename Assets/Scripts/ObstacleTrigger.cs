using UnityEngine;
using System.Collections;

public class ObstacleTrigger : MonoBehaviour {



    public float slow = 5;

    public float drugTime = 10;

    public float colorTicks = 2;

    public bool getKarma = true;

    public Obstacle thisObstacle = Obstacle.puddle;
    public GameObject camera2;
    public GameObject drugCamera;
    public GameMode gameMode;
   
    void Start(){
        switch (thisObstacle)
        {
            case Obstacle.red:
                StartCoroutine(Wait(colorTicks));
                break;
            case Obstacle.blue:
                StartCoroutine(Wait(colorTicks));
                break;
            case Obstacle.green:
                StartCoroutine(Wait(colorTicks));
                break;
        }
    }
    
    void OnTriggerStay2D(Collider2D collider)
    {        
        if(collider.gameObject.CompareTag("PlayerFeet"))
        {
            switch (thisObstacle)
            {
                case Obstacle.puddle:
                    collider.transform.parent.parent.GetComponent<Character>().speed = slow;
                    break;
                case Obstacle.red:
                    if((int)gameMode.activeColor == (int)Obstacle.red){
                        if(getKarma){
                            getKarma = false;
                            collider.transform.parent.parent.GetComponent<PlayerStats>().karma += 1;

                        }
                    } 

                    break;
                case Obstacle.blue:
                    if((int)gameMode.activeColor == (int)Obstacle.blue){
                        if(getKarma){
                            getKarma = false;
                            collider.transform.parent.parent.GetComponent<PlayerStats>().karma += 1;
                            
                        }
                    } 
                    
                    break;
                case Obstacle.green:
                    if((int)gameMode.activeColor == (int)Obstacle.green){
                        if(getKarma){
                            getKarma = false;
                            collider.transform.parent.parent.GetComponent<PlayerStats>().karma += 1;
                            
                        }
                    } 
                    
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
           default :
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
                case Obstacle.red:
                    if((int)gameMode.activeColor != (int)Obstacle.red){
                        RandomEffect(collider.transform.parent.parent);
                    } 
                    
                    break;
                case Obstacle.blue:
                    if((int)gameMode.activeColor != (int)Obstacle.blue){
                        RandomEffect(collider.transform.parent.parent);
                    } 
                    
                    break;
                case Obstacle.green:
                    if((int)gameMode.activeColor != (int)Obstacle.green){
                        RandomEffect(collider.transform.parent.parent);
                    }
                    break;
            }          
            
        }
    }
    void RandomEffect(Transform player){
        int index = Random.Range(1, 5);
        switch(index){
            case 1 :
                player.GetComponent<HealthController>().ApplyDamage(9999999999999999999);
                player.GetComponent<PolygonCollider2D>().enabled = false;
                break;
            case 2 :
                player.GetComponent<Character>().speed = slow;
                break;
            case 3 :
                player.GetComponent<Character>().speed = slow * 3;
                break;
            case 4 :
                player.GetComponent<Character>().dontInvert = true;
                break;
        }
    }

    IEnumerator Wait(float time)
    {

        yield return new WaitForSeconds(time);
        getKarma = true;
        StartCoroutine(Wait(time));

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
        camera2.SetActive(false);
        yield return new WaitForSeconds(drugTime);
        camera2.SetActive(true);
        drugCamera.SetActive(false);
        foreach (GameObject player in players)
        {
            player.GetComponent<Character>().dontInvert = true;
            
            
        }
        Destroy(gameObject);
    }

}
