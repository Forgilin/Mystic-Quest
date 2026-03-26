using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    //Player variables
    public float speed = 12f;
    public float jumpHeight = 4f;
    public float gravity = -9.81f *3f;


    //ground check
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    //stamina bar
    public float timer;
    public float disolveTimer;
    public float currentStamina;
    public float maxStamina = 100;

    public GameObject staminaBar;
    [SerializeField] private Image image;

    //Variables for stunning player
    [SerializeField] bool enemyTriggerNeed = false;
    [SerializeField] private bool stunned = false;


    //Sounds
    [SerializeField] private AudioSource footStepSound;
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioClip jumpSound;

    public GameObject player;
    public Player playerScript;

    
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        disolveTimer = 1.5f;
        image.color = new Color (255,255,255,255);

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking if player is stunned
        if(enemyTriggerNeed)
        {
            stunned = EnemyTrigger.stunned;
        }


        //Stamina timer
        timer += Time.deltaTime;

        //Waiting to animate stamina bar disolve
        if(currentStamina == maxStamina)
        {
            disolveTimer += Time.deltaTime;
        }

        //Checking if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        //Sprinting
        if(Input.GetKey(KeyCode.LeftShift) && currentStamina >1 && !stunned)
        {
            speed = 20f;
            disolveTimer = 0;
            FadeIn();
            currentStamina -= 10 * Time.deltaTime;
            timer = 0;
            staminaBar.transform.localScale = new Vector2(currentStamina/100, 1f);
            footStepSound.pitch = 1.2f;
        }
        else
        {
            speed = 12f;
            footStepSound.pitch = 1f;
        }

        //Footsteps
        if(isGrounded && !PauseMenu.paused && !stunned && !playerScript.newGame && !playerScript.gameFinished && !playerScript.difficultySelection)
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                footStepSound.enabled = true;
            }
            else
            {
                footStepSound.enabled = false;
            }
        }
        else
        {
            footStepSound.enabled = false;
        }


        //Stamina
        if(timer > 1)
        {
            if(currentStamina<maxStamina)
            {
                currentStamina += 20 * Time.deltaTime;
                staminaBar.transform.localScale = new Vector2(currentStamina/100, 1f);
            }
            else
            {
                currentStamina = maxStamina;
            }
        }

        if(disolveTimer >=0.5f)
        {
            FadeOut();
        }

        if(!stunned && !PauseMenu.paused && !playerScript.newGame && !playerScript.gameFinished && !playerScript.difficultySelection)
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        //Checking if player is able to jump
        if(Input.GetButtonDown("Jump") && isGrounded && !stunned && !playerScript.newGame && !playerScript.difficultySelection && !playerScript.gameFinished)
        {
            jumpSource.PlayOneShot(jumpSound);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        if(!stunned && !PauseMenu.paused && !playerScript.newGame && !playerScript.gameFinished && !playerScript.difficultySelection)
        {
            controller.Move(velocity * Time.deltaTime);
        }

    }

    //Fade out function for stamina bar
    public void FadeOut()
    {
        image.CrossFadeAlpha(0,0.5f,true);
    }

    //Fade in function for stamina bar
    public void FadeIn()
    {
        image.CrossFadeAlpha(1,0.5f,true);
    }

}
