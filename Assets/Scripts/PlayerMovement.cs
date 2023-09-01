using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
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
    public GameObject pickedUpBow;

    [SerializeField] private AudioClip pickUpBow;

    public AudioSource audioSource;

    [Header("Audio")]
    [SerializeField] private AudioClip[] walkSounds;
    [SerializeField] private AudioClip[] runSounds;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;

    private bool isRunning = false;
    private bool wasGrounded = true;

    public float jumpForce;

    public Camera cam;
    Vector3 velocity;
    bool isGrounded;
    Vector3 move;
    bool isOnJumpPad;

    [SerializeField] private AudioClip respawnSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();

        isRunning = false;

        speed = walkSpeed;
    }

   private void Update()
        {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        

        cc.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlaySound(jumpSound);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        
        cc.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 90, t);
            speed = runSpeed;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, t);
            speed = walkSpeed;
            isRunning = false;
        }
        HandleMovementSound();
        HandleJumpPad();

        if(PauseMenu.gameIsPaused)
        {
            audioSource.volume = 0;
        }
        if (PauseMenu.gameIsPaused == false)
        {
            audioSource.volume = 1;
        }
    }
    private void LateUpdate()
    {
        if (isGrounded && !wasGrounded)
        {
            PlaySound(landSound);
        }
        wasGrounded = isGrounded;
    }
    private void HandleMovementSound()
    {
        if (isGrounded && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            AudioClip[] soundsToPlay = isRunning ? runSounds : walkSounds;
            PlayRandomSound(soundsToPlay);
        }
    }
    private void HandleJumpPad()
    {
        if (isOnJumpPad) 
        {
            ApplyJumpPadForce(jumpForce);
        }
    }
    public void ApplyJumpPadForce(float force)
    {
        velocity.y = Mathf.Sqrt(force * -2f * gravity);
    }
    private void PlayRandomSound(AudioClip[] clips)
    {
        if (clips.Length > 0 && !audioSource.isPlaying)
        {
            int randomIndex = Random.Range(0, clips.Length);
            audioSource.clip = clips[randomIndex];
            audioSource.Play();
        }
    }
    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BowPickup"))
        {
            SoundEffectManager.Instance.PlaySoundFXClip(pickUpBow, transform, 1f);
            pickedUpBow.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Respawn")
        {
            Respawn();

        }

    }
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

