
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float maxVelocity = 5f;

    private Rigidbody2D _myBody;
    private Animator _animator;

    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovePlayerKeyboard();
    }

    void MovePlayerKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(_myBody.velocity.x);

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

            _animator.SetBool("isWalking", true);
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

            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        _myBody.AddForce(new Vector2(forceX, 0));

    }
}
