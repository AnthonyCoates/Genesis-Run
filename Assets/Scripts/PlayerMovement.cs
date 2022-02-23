using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isJumping = false;
    private bool isFalling = false;

    private float movementSpeed = 5f;
    private const float maxSpeed = 25f;
    private const float increaseSpeed = 1f;

    private const float jumpSpeed = 10f;
    private const float fallSpeed = 7f;

    private const float jumpHeight = 2f;
    private float groundHeight;

    private GameObject mainCamera;
    private Animator playerAnimator;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerAnimator = GetComponent<Animator>();

        groundHeight = transform.position.y;
    }

    void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void MovePlayer()
    {
        if (movementSpeed < maxSpeed)
        {
            movementSpeed += increaseSpeed * Time.deltaTime;
        }

        transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
        mainCamera.transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
    }

    private void JumpPlayer()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            && !isJumping)
        {
            isJumping = true;
            playerAnimator.SetBool("isJumping", true);
        }

        if (isJumping && !isFalling && transform.position.y < jumpHeight)
        {
            transform.Translate(0f, jumpSpeed * Time.deltaTime, 0f);
        }
        else if (transform.position.y >= jumpHeight)
        {
            isFalling = true;
        }

        if (isFalling && transform.position.y > groundHeight)
        {
            transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
        }
        else if (isFalling && transform.position.y <= groundHeight)
        {
            transform.position = new Vector3(transform.position.x, groundHeight, transform.position.z);

            isJumping = false;
            isFalling = false;

            playerAnimator.SetBool("isJumping", false);
        }
    }
}
