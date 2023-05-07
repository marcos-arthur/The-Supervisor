using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour

{
    [SerializeField] private int speed;
    [SerializeField] private GameObject levelBackground;

    private Animator animator;

    private float xMin = -8.6f, xMax = 8.51f;
    private float yMin = 4.6f, yMax = 21.5f;

    private float xMinBackground = 401.94f, xMaxBackground = 414.59f;
    private float yMinBackground = 217.6f, yMaxBackground = 232.01f;

    private bool isLookingLeft = false;
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void move()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Time.deltaTime * speed;

        if (movement.x > 0)
        {
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingHorizontal", true);
            if (isLookingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isLookingLeft = false;
            }
        }

        if (movement.x < 0)
        {
            if (isColliding)
            {
                movement.x = 0;
            }
            else
            {
                animator.SetBool("isWalkingUp", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingHorizontal", true);
                if (!isLookingLeft)
                {
                    transform.Rotate(0f, 180f, 0f);
                    isLookingLeft = true;
                }
            }
        }

        if(movement.y > 0)
        {
            if (isColliding)
            {
                movement.y = 0;
            }
            else
            {
                animator.SetBool("isWalkingUp", true);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingHorizontal", false);
            }
            
        }

        if (movement.y < 0)
        {
            if (isColliding)
            {
                movement.y = 0;
            }
            else
            {
                animator.SetBool("isWalkingUp", false);
                animator.SetBool("isWalkingDown", true);
                animator.SetBool("isWalkingHorizontal", false);
            }
        }

        if(movement.y == 0 && movement.x == 0)
        {
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingHorizontal", false);
        }

        float xValidPosition = Mathf.Clamp(transform.position.x + movement.x, xMin, xMax);
        float yValidPosition = Mathf.Clamp(transform.position.y + movement.y, yMin, yMax);

        float xValidPositionBackground = Mathf.Clamp(levelBackground.transform.position.x - movement.x, xMinBackground, xMaxBackground);
        float yValidPositionBackground = Mathf.Clamp(levelBackground.transform.position.y - movement.y, yMinBackground, yMaxBackground);

        // transform.position = new Vector3(xValidPosition, yValidPosition, 0f);
        levelBackground.transform.position = new Vector3(xValidPositionBackground, yValidPositionBackground, 0f);

        // transform.position += movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stolen item")
        {
            SceneManager.LoadScene("Final Tutorial Game", LoadSceneMode.Additive);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "coliders")
        {
            //isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coliders")
        {
            isColliding = false;
        }
    }
}
