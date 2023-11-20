using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KarakterKontroller : MonoBehaviour
{
    private float horizontal;
    private float kontrollerHorizontal;
    public Vector2 velocity;
    private float lagretHorizontal;
    public float speed;
    public float topSpeed;
    public float jumpingPower;
    private bool isFacingRight = true;
    public float luftKontroll;
    public float friction;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public GameObject Kamera;
    public Transform kameraTransform;
    [SerializeField] private float tyngdekraft;
    [SerializeField] private float hoppeTyngdekraft;
    [SerializeField] private float bufferTid;
    [SerializeField] private float coyoteTime;
    [SerializeField] private float lookAhead;
    private float coyoteTimer;
    private bool falleTyngdkraft;
    private bool hoppe;
    public bool fullLuftKontroll;

    private void Start()
    {
        //denne finner kameraet
        Kamera = GameObject.FindGameObjectWithTag("Kamera");
        kameraTransform = Kamera.GetComponent<Transform>();
    }
    void Update()
    {
        //denne tar inn kontrollerinputet
        kontrollerHorizontal = Input.GetAxisRaw("Horizontal");

        //denne fikser luftkontroll
        if (fullLuftKontroll == false)
        {
            if (coyoteTimer > 0)
            {

                horizontal = kontrollerHorizontal;
                lagretHorizontal = kontrollerHorizontal;
            }
            else
            {
                horizontal = ((kontrollerHorizontal * luftKontroll) + (lagretHorizontal / luftKontroll)) / 2;
            }
        }
        else
        {
            horizontal = kontrollerHorizontal;
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

        //denne flytter på kameraet
        kameraTransform.position = new Vector3(transform.position.x+lookAhead, 0,-10);
        //denne gjør at du snur deg etter hvilken vei du går
        flip();
        
        //denne fikser bevegelse, med akselrasjon og deakselrasjon
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, friction * Time.deltaTime);
        }
        velocity.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, -topSpeed, topSpeed);
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

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
