using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravity = -9.81f;
    private float gravityCof = -3.0f;
    private CharacterController controller;
    private Vector3 velocity;
    private Transform mainCamera;
    private ScoreManager scoreManager;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 rotF = mainCamera.forward.normalized;
        Vector3 rotR = mainCamera.right.normalized;
        rotF.y = 0f;
        rotR.y = 0f;

        controller.Move((h * rotR.normalized + v * rotF.normalized) * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * gravityCof * gravity);
        }
        
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mashroom")
        {
            Destroy(other.gameObject);
            scoreManager.Increment();
        }
    }
}
