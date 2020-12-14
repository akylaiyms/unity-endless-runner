using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float movementSpeed; 
    public RoadSpawner roadSpawner;

    private Rigidbody rb; 
    private Animator anim;
    private int health;
    private int score;
    private UserInterfaceManager userInterfaceManager;

    // for restart menu 
    public string restartMenuScene;
    // for coin collecting and obstacle hitting audio 
    public AudioClip coin;
    public AudioClip oof;
    public AudioClip jump;
    public AudioClip slide;
    AudioSource audioSource;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        userInterfaceManager = GameObject.Find("UserInterfaceManager").GetComponent<UserInterfaceManager>();

        // set initial health amount
        SetHealthTo(3);

        // set initial score
        SetScoreTo(0);

        // getting audiosource components from Timmy 
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        // handle player movement here
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        transform.Translate(new Vector3(hMovement, 0, 10) * Time.deltaTime);


        // handle player animations here
        if (Input.GetKeyDown (KeyCode.UpArrow) && gameObject.transform.position.y <= 0){
            anim.SetBool("IsJumping", true );
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(jump, 1f);
        } else {
            anim.SetBool ("IsJumping", false);
        }

        if (Input.GetKeyDown (KeyCode.DownArrow)){
            anim.SetBool("IsSliding", true );
            audioSource.PlayOneShot(slide, 1f);
        } else {
            anim.SetBool ("IsSliding", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.CompareTag("Obstacle")) {
            SetHealthTo(health - 1);
            // play oof audio 
            audioSource.PlayOneShot(oof, 1f);
        } if (other.gameObject.CompareTag("Collectible")) {
            SetScoreTo(score + 1);
            other.gameObject.SetActive(false);
            // play coin audio 
            audioSource.PlayOneShot(coin, 1f);
        } else {
            roadSpawner.MoveRoad(); 
        }
    }

    private void SetHealthTo(int newHealth) {
        health = newHealth;
        // update health bar here
       UIHealthBar.instance.SetValue(health / 3f);
        if (health == 0) {
            // activate RESTART page
            RestartGame();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(restartMenuScene);
    }
    
    private void SetScoreTo(int newScore) {
        score = newScore;
        // update score UI here
        userInterfaceManager.updateScoreUI(score);
    }
}
