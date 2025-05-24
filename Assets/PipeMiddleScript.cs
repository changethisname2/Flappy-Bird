using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript bird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // When game starts, find game object with tag logic, then get the LogicScript component
        logic = GameObject.Find("Logic Manager").GetComponent<LogicScript>(); // Find using gameobject name
        bird = GameObject.Find("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is the player by checking its layer
        if (collision.gameObject.layer == 3 && bird.birdIsAlive) 
        {
            //Debug.Log(collision); // collision will show the name of gameobject which pipe middle collided with
            logic.addScore(1);
        }
    }
}
