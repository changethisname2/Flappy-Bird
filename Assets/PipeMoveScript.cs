using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public GameObject bird;
    public float moveSpeed = 5;
    public float deadZone = -45;
    public Rigidbody2D rb;
    public ParticleSystem clouds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bird = GameObject.Find("Bird"); // Find the bird object in the scene
        clouds = GameObject.Find("Particle System").GetComponent<ParticleSystem>(); // Find the particle system in the scene
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.transform.position.y > -26.6 && bird.transform.position.x > -45)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, 0); // Move the pipe to the left at the specified speed
            //transform.position += Vector3.left * moveSpeed * Time.deltaTime; //deltaTime is the time between frames, so 30fps and 60fps will be the same
        } else
        {
            rb.linearVelocity = Vector2.zero; // Stop the pipe when the bird is out of bounds
            if (clouds != null)
            {
                clouds.Stop(true, ParticleSystemStopBehavior.StopEmitting);

                var main = clouds.main;
                main.simulationSpeed = 0;
            }
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject); //Destroy the object when it goes out of bounds
        }
    }
}
