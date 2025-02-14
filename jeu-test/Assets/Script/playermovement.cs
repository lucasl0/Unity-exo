using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public float moveDirectionX = 0;
    public float moveSpeed = 10;

    public float jumpForce = 7;

    public Transform groundCheck;

    public float groundCheckRadius = 0.2f;

    public bool isGrounded = false;
    
    public LayerMask listGroundLayers;

    public int maxAllowedJumps = 3;
    public int currentNumberJumps = 0;
    public bool isFacingRight = false;
    public voidEventChannel onPlayerDeath;
    private void OnEnable(){
        onPlayerDeath.OnEventRaised += Die;

    }
    private void OnDisable(){
        onPlayerDeath.OnEventRaised -= Die;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Die(){
        bc.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirectionX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") 
        && currentNumberJumps < maxAllowedJumps)
        {
            Jump();
            currentNumberJumps++;
        }
        if (
            isGrounded && 
            !Input.GetButton("Jump")
            ){
                currentNumberJumps = 0;
                }
                Flip();
    } 
     void Flip(){
        if (
            (moveDirectionX > 0 && !isFacingRight) ||
            (moveDirectionX < 0 && isFacingRight)
        ){
            transform.Rotate(0,180,0);
            isFacingRight = !isFacingRight;
        }
    }         
    private void Jump(){
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );
    }
    private void FixedUpdate(){
        rb.linearVelocity = new Vector2 (
            moveDirectionX * moveSpeed,
            rb.linearVelocity.y
        );
        isGrounded = IsGrounded();
    }
    public bool IsGrounded(){
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            listGroundLayers
        );
        }
    private void OnDrawGizmos() {
        if (groundCheck != null ){
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(
            groundCheck.position,
            groundCheckRadius
        );
        }
    
    }
}


