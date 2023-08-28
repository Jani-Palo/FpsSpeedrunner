using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Sliding")]
    public bool isSliding = false;
    public float slideSpeed = 10f;
    public float slideDuration = 1f;
    private float slideTimer = 0f;
    private Vector3 slideDirection;
    private Vector3 originalScale;


    CharacterController cc;
    float speed;
    public float runSpeed;
    public float walkSpeed;

    public float t = .1f;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDist = .4f;
    public LayerMask groundLayer;
    public float jumpHeight = 5f;

    public  GameObject spawnPoint;
    public GameManager manager;


    public Camera cam;
    Vector3 velocity;
    bool isGrounded;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDist,groundLayer);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = (isSliding ? slideDirection : (transform.right * x + transform.forward * z));

        cc.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        
        cc.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 90, t);
            speed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, t);
            speed = walkSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            StartSliding();
        }
        if (isSliding)
        {
            UpdateSlide();
            float scaleFactor = Mathf.Lerp(transform.localScale.x, originalScale.x * 0.8f, slideTimer / slideDuration);
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
    }
    private void StartSliding()
    {
        isSliding = true;
        slideTimer = 0f;
        slideDirection = move.normalized;
        Vector3 newScale = originalScale * .6f; 
        transform.localScale = newScale;
        speed = slideSpeed;
    }

    private void UpdateSlide()
    {
        slideTimer += Time.deltaTime;
        if (slideTimer >= slideDuration)
        {
            EndSliding();
        }
    }

    private void EndSliding()
    {
        isSliding = false;
        speed = walkSpeed;
        // Restore the player's original scale
        transform.localScale = originalScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Portal")
        {
            DontDestroyOnLoad(manager);
            GameManager.instance.loadNextLevel();
           
        }
    }
    public void Respawn()
    {
        this.gameObject.transform.position = spawnPoint.transform.position;
    }
   
}

