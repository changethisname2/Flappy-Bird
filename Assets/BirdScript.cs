using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject startText;
    public GameObject optionsMenu;
    public AudioSource flapSound;
    public AudioSource crashSound;
    public ParticleSystem clouds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        transform.position = new Vector3(-20, 0, 0); // Set the initial position of the bird to -20 on the x-axis
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive && Time.timeScale == 1)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            flapSound.Play();
        }

        if (Mathf.Abs(transform.position.y) > 26.6 && birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

        if (transform.position.y < -26.6)
        {
            myRigidBody.gravityScale = 0;
            myRigidBody.linearVelocity = Vector2.zero;
            myRigidBody.angularVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !logic.gameOverScreen.activeSelf && !startText.activeSelf)
        {
            if (optionsMenu.activeSelf)
            {
                logic.pauseMenu.SetActive(true);
                logic.playButtonClick();
            }
            else
            {
                if (Time.timeScale == 1)
                {
                    logic.pauseGame();
                }
                else if (Time.timeScale == 0)
                {
                    logic.resumeGame();
                }
            }
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            crashSound.Play();
            logic.gameOver();
        }
        birdIsAlive = false;
    }
}
