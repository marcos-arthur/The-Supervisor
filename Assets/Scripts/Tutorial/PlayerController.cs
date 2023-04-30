using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;

    [SerializeField] 
    private int speed;

    private bool isLookingLeft = false;
    private bool isHittingWall = false;

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
            if (isHittingWall)
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
            if (isHittingWall)
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
            if (isHittingWall)
            {
                movement.y = 0;
            }
            else
            {
                animator.SetBool("isWalkingUp", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingHorizontal", false);
            }
        }

        if(movement.y == 0 && movement.x == 0)
        {
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingHorizontal", false);
        }

        transform.position += movement;
    }
}
