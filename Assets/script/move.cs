using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    Animator animator;

    bool isGrounded;

    Vector2 velocity;

    public float speed = 1.0f;
    public float jumpForce = 4f;
    private bool isJumping = false;
    private bool isFalling = false;

    [SerializeField] GameObject bodyObject;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = bodyObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float _hozInput = Input.GetAxisRaw("Horizontal");

        velocity = new Vector2(_hozInput, 0).normalized * speed;
        
        if (velocity.x != 0)
        {
            animator.SetBool("iswalk", true);
        }
        else
        {
            animator.SetBool("iswalk", false);
        }
        if (_hozInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_hozInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isjp", true);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
        if (isJumping && rigidbody.velocity.y <= 0 && !isFalling)
        {
            animator.SetBool("isjpf", true);
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        // ĳ���Ͱ� ���� ����� �� ���� ���¸� false�� ����
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isFalling = false;
            animator.SetBool("isjp", false);
        }
        if (collision.contacts.Length > 0)
        {
            ContactPoint2D contact = collision.contacts[0];
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
            {
                isGrounded = true;
                animator.SetBool("isjp", false); // ���� �� ����
                animator.SetBool("fall", false); // ���� �� ���� �� �ƴ�
            }
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(velocity.x, rigidbody.velocity.y);

        if (rigidbody.velocity.y < 0 && !isGrounded)
        {
            animator.SetBool("fall", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}