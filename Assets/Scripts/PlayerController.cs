using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimation;
    private AudioSource playerAudio;


    // Two variables for both audio and particles.
    public ParticleSystem explosionPrt;
    public ParticleSystem dirtPrt;
    public AudioClip jumpingSound;
    public AudioClip crashingSound;

    // The force to make player jump
    public float jumpHeight = 13.0f;

    // The component to actually modify the gravity value
    public float gravityModifier;

    // To avoid double jump using a boolean value to check if the player is on the ground or not
    public bool isOnGround = true;

    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            dirtPrt.Stop();
            playerAudio.PlayOneShot(jumpingSound,0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtPrt.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over");
            playerAnimation.SetBool("Death_b",true);
            playerAnimation.SetInteger("DeathType_int",1);
            explosionPrt.Play();
            dirtPrt.Stop();
            playerAudio.PlayOneShot(crashingSound,0.0f);
        }
    }
}
