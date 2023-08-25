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

    public GameObject spawnPoint;
    public GameManager manager;

    public Camera cam;
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
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

        Vector3 move = transform.right * x + transform.forward * z;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            this.gameObject.transform.position = spawnPoint.transform.position;
        }
        if (other.gameObject.tag == "Portal")
        {
            DontDestroyOnLoad(manager);
            GameManager.instance.loadNextLevel();
           
        }
    }
}
