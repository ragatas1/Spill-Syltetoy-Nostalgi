using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpingPower;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float tyngdekraft;
    [SerializeField] private float hoppeTyngdekraft;
    [SerializeField] private float bufferTid;
    [SerializeField] private float coyoteTime;
    private bool falleTyngdkraft;
    private bool hoppe;
    private bool paBakken;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Hoppe());
        }
        if (IsGrounded()) 
        {
            paBakken = true;
        }
        else
        {
            StartCoroutine (PaBakken());
        }
        if (hoppe == true && paBakken == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (rb.velocity.y > 0 && Input.GetButton("Jump"))
        {
            falleTyngdkraft = true;
        }
        else
        {
            falleTyngdkraft = false;
        }
        if (falleTyngdkraft == true)
        {
            rb.gravityScale = hoppeTyngdekraft;
        }
        else
        {
            rb.gravityScale = tyngdekraft;
        }

        flip();
    }
    private void FixedUpdate () 
    {
      rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
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
    private IEnumerator Hoppe()
    {
        hoppe = true;
        yield return new WaitForSeconds(bufferTid);
        hoppe = false;
    }
    private IEnumerator PaBakken()
    {
        yield return new WaitForSeconds(coyoteTime);
        paBakken = false;
        Debug.Log("coyote ferdig");
    }
}
