using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KarakterKontroller : MonoBehaviour
{
    private float horizontal;
    private float kontrollerHorizontal;
    private float lagretHorizontal;
    public float speed;
    public float runSpeed;
    public float jumpingPower;
    private bool isFacingRight = true;
    private float iLufta;
    public float luftKontroll;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float tyngdekraft;
    [SerializeField] private float hoppeTyngdekraft;
    [SerializeField] private float bufferTid;
    [SerializeField] private float coyoteTime;
    private float coyoteTimer;
    private bool falleTyngdkraft;
    private bool hoppe;
    private bool lope;

    void Update()
    {
        //denne tar inn kontrollerinputet
        kontrollerHorizontal = Input.GetAxisRaw("Horizontal");

        //denne fikser luftkontroll
        if (coyoteTimer>0)
        {

            horizontal = kontrollerHorizontal;
            lagretHorizontal = kontrollerHorizontal;
        }
        else
        {
            horizontal = ((kontrollerHorizontal*luftKontroll) + (lagretHorizontal/luftKontroll))/2;
        }

        //denne starter coroutinen til hoppebufring
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Hoppe());
        }

        //denne fikser coyote time
        if (IsGrounded())
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer = coyoteTimer -1*Time.deltaTime;
        }
        //denne hopper
        if (hoppe == true && coyoteTimer>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //denne gjør tyngedekraften annerledes når du prøver å hoppe
        if (rb.velocity.y > 0 && Input.GetButton("Jump"))
        {
            falleTyngdkraft = true;
        }
        else
        {
            falleTyngdkraft = false;
        }

        //denne endrer tyngedekraften
        if (falleTyngdkraft == true)
        {
            rb.gravityScale = hoppeTyngdekraft;
        }
        else
        {
            rb.gravityScale = tyngdekraft;
        }
        //denne gjør at man ikke kan slutte å løpe hvis man er i lufta
        if (coyoteTimer > 0)
        {
            if (Input.GetButton("Run"))
            {
                lope = true;
            }
            else 
            {
                lope = false; 
            }
        }
        //denne gjør at du snur deg etter hvilken vei du går
        flip();
    }
    private void FixedUpdate () 
    {
        //denne gjør at du kan bevege deg
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);

        //denne gjør at du går fortere når du trykker på løpeknappen
        if (lope == true)
        {
            rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
        }
    }
    //denne sjekker at du er på bakken
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //denne flipper deg
    private void flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f; 
            transform.localScale = localScale;
        }
    }

    //dette er coroutinen for hoppebufring
    private IEnumerator Hoppe()
    {
        hoppe = true;
        yield return new WaitForSeconds(bufferTid);
        hoppe = false;
        coyoteTimer = 0;
    }
}
