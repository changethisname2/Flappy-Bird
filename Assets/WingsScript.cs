using UnityEngine;

public class FlappingScript : MonoBehaviour
{
    public BirdScript bird;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        animator.SetBool("birdIsAlive", bird.birdIsAlive);
    }
}
