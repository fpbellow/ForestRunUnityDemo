using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private GameManager gameManager;

    public ParticleSystem explosionPart;
    public ParticleSystem dirtPart;

    public AudioClip crashSound;
    public AudioClip jumpSound;

    public float jumpforce = 20f;

    
    private bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded && gameManager.isGameActive)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            grounded = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 0.45f);
            dirtPart.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            dirtPart.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle_Danger"))
        {
            gameManager.GameOver();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            explosionPart.Play();
            playerAudio.PlayOneShot(crashSound, 1.2f);
            dirtPart.Stop();
        }
    }
}
