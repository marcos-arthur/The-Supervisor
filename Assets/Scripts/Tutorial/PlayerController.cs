using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private float xMin = -6.16f, xMax = 10.89f;
    private float yMin = -24.84f, yMax = -8.15f;

    [SerializeField] 
    private int speed;

    private bool isLookingLeft = false;
    private bool isHittingSomething = false;

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
            if (isHittingSomething)
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
            if (isHittingSomething)
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
            if (isHittingSomething)
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

        transform.position = new Vector3(xValidPosition, yValidPosition, 0f);

        // transform.position += movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Stolen item")
        {
            SceneManager.LoadScene("Final Tutorial Game", LoadSceneMode.Additive);
        }

        if (collision.gameObject.tag == "colliders")
        {
            isHittingSomething = true;
        }
    }
}
