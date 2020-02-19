using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public Animator animator;
    public float moveSpeed = 5f;
    public bool isGrounded = false;

    bool jump = false;
    bool crouch = false;
    float horizontalMove = 0f;
    public float runSpeed = 30f;

    public bool facingRight;


    public Transform attackPoint;
    public float attachRange = 0.5f;
    public int attackDamage = 20;

    public LayerMask enermyLayers;
    public Joystick joystick;
    




    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        // Attack();
        Roll();
        // Constantly check for movement
        Vector3 movement = new Vector3(joystick.Horizontal , 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed; // get constant rate and multiply by speed

        float horizontalMove = joystick.Horizontal  * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        Flip(horizontalMove);


    }

    void Roll()
    {
        if (joystick.Vertical <= -.5f )
        {

            animator.SetTrigger("Roll");

        }
    }
    void Jump()
    {
        if (joystick.Vertical >= .5f && isGrounded == true)
        {
            // add force to rigid body 2d component
            Vector2 force = new Vector2(0f, 5f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");

        }

    }

    public void Attack()
    {

        Debug.Log("Atttttack");
        // if (Input.GetKeyDown(KeyCode.X))
        // {
            // Aimation
            animator.SetTrigger("Attack");
            //  Detect colloders
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attachRange, enermyLayers);

            // Damege them
            foreach (Collider2D e in hitEnemy)
            {
                // Damage!!!
                Debug.Log("Hiiit");

                e.GetComponent<Enemy>().Damage(attackDamage);

            }

        // }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attachRange);
    }

    void Flip(float horizontal)
    {

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
