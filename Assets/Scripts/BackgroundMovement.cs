using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject[] backgroundsBack;
    public GameObject[] backgroundsMiddle;
    public GameObject[] backgroundsFront;
    public GameObject[] backgroundsObjects;

    private const float backSpeed = 0.1f;
    private const float middleSpeed = 0.3f;
    private const float backgroundWidth = 21.6f;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        MoveAllBackgrounds();
    }

    private void MoveAllBackgrounds()
    {
        float moveSpeed = playerMovement.GetSpeed();

        MoveBackgrounds(backgroundsBack, moveSpeed - (moveSpeed * backSpeed));
        MoveBackgrounds(backgroundsMiddle, moveSpeed - (moveSpeed * middleSpeed));
        MoveBackgrounds(backgroundsFront, 0f);
        MoveBackgrounds(backgroundsObjects, 0f);
    }

    private void MoveBackgrounds(GameObject[] bgArray, float bgSpeed)
    {
        foreach (GameObject bg in bgArray)
        {
            if (bg.transform.position.x < transform.position.x - backgroundWidth)
            {
                bg.transform.Translate(backgroundWidth * bgArray.Length, 0f, 0f);
            }

            bg.transform.Translate(bgSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
