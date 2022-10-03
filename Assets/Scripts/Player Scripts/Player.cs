
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float maxVelocity = 5f;

    private Rigidbody2D myBody;
    private Animator animator;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovePlayerKeyboard();
    }

    void MovePlayerKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            animator.SetBool("isWalking", true);
        }
        else if (horizontalInput < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));

    }
}
