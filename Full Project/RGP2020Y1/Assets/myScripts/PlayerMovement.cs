using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://www.caseportman.com/single-post/2018/08/16/Input-Buffering-2D-Platforming
/// this script is attached to player
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;//reference to rigidbody2D
    float moveDir;
    //bool isFacingRight = true;
    public Animator anim;//reference to player animator
    public AnimatorFunctions animatorFunctions;//Reference to AnimatorFunctions script which in charge of all the functions for playing sound and particle effect
    public VectorValue startingPostion;//Reference to scriptable object script which will alter the player position when changing scene

    [Header("Invulnerable Frame")]
    public Color flashingColor;//The color flashing
    public Color defaultColor;//The default color of the sprite
    public float flashDuration;//The length of flashing duration
    public int howManyTimeToFlash;
    public Collider2D triggerCollider;
    public SpriteRenderer sprite;
    public bool isHurt;

    //[Header("Jump fall multiplier")]
    //public float fallMultiplier;//This will increase the gravity drag when player fall

    [Header("Jump buffering")]
    //Timer for jump buffering
    public float jumpPressedRememerTime; //Reset timer
    float jumpPressedRemember; //Timer which will be decreased

    [Header("Coyote time")]
    //Timer for ground coyote time
    public float groundedRememberTime; //Reset timer
    float groundedRemember; //Timer which will be decreased

    [Header("Check ground")]
    public Collider2D feetToGround; //A 'bool' variable to check if the player is on the ground
    public GameObject feet; //A reference to the player on ground state to reset jump, used in script which restrict the player jump input (E.G. Bouncy objects)
    public float feetRadius; //The range which feetToGround returns true
    public LayerMask whatIsGround; //feetToGround returns true if in the range and detect ground layer


    [Header("Player controller value")]
    public float speed;//Movement speed
    public float jumpForce;//Jump height

    private void Start()
    {
        //Set the player postion to the postion in VectorValue scriptable object script
        transform.position = startingPostion.initialValue; 
        //Get the rigid body of the player
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        MovementInput();
        CheckGround();
        JumpStateMachine();
        Jump();
    }



    private void MovementInput()
    {
        moveDir = Input.GetAxisRaw("Horizontal");//Get a float value when player press key board (1 when player presses D, ->, -1 when player presses A, <-)s


        if(moveDir != 0) //player is moving
        {
            anim.SetBool("isRunning", true); //Set isRunning to true so that unity will play 
            //Check if player holding moving right button
            if (moveDir > 0 /*&& !isFacingRight*/) //Player moving to the right
            {
                //Flip();

                //Set player rotation to default rotations
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            //Check if player holding moving left button
            else if (moveDir < 0 /*&& isFacingRight*/) //Player moving to the left
            {
                //Flip();

                //Flip the player horizontally as the default sprite is facing right
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            anim.SetBool("isRunning", false); //Return to idle mode in animation when player is not moving
        }
    }

    private void CheckGround()
    {
        //a bool/circle collider range to check if the player is grounded
        feetToGround = Physics2D.OverlapCircle(feet.transform.position, feetRadius, whatIsGround);

        //Coyote time application
        //Start the timer
        groundedRemember -= Time.deltaTime;
        if (feetToGround)
        {
            //Reset the timer/Stop the timer if the player is on the ground 
            groundedRemember = groundedRememberTime;
            //isJumping = false;
        }
    }


    //Called in bouncy objects too
    public void JumpStateMachine()
    {
        //Debugging the velocity
        anim.SetFloat("VerticalVelocity", rb.velocity.y);

        //If verticle movement is downward/decreasing (player is falling), play the falling animation and stop playing jump animation
        if (rb.velocity.y < 0)
        {
            //Play falling animation
            anim.SetBool("isFalling", true);

            //Stop jumping animation
            anim.SetBool("isJumping", false);
        }
        else if (rb.velocity.y == 0) //No verticle movement (player is on the ground), stop the falling animation which will start playing either running or idling animation based on player input when landing
        {
            anim.SetBool("isFalling", false);
        }
    }

    private void FixedUpdate()
    {
        Movement();
        
    }

    private void Movement()
    {
        //Move player by changing the horizontal velocity according to player input
        rb.velocity = new Vector2(moveDir * speed *Time.fixedDeltaTime, rb.velocity.y);
    }

    private void Jump()
    {
        //Debug.Log("Time remembered" + jumpPressedRemember);

        //Timer
        jumpPressedRemember -= Time.fixedDeltaTime;

        //Set jump buffering value to a float
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
        {
            //Reset the timer
            jumpPressedRemember = jumpPressedRememerTime;
            //Check if the player has pressed the jump button in the last jumpPressedRememberTime and the player was on the ground during the last timer groundedRemember
            //if yes then jump
            if(((jumpPressedRemember > 0) && (groundedRemember > 0)))
            {
                //isJumping = true;
                //if (isJumping)
                //{
                //}

                //When jumping set timer value to 0 to stop multiple jump
                groundedRemember = 0;
                jumpPressedRemember = 0;

                //Change the verticle movement with the speed of jumpForce
                rb.velocity = Vector2.up * jumpForce * Time.fixedDeltaTime;

                //Stop on ground animation
                anim.SetBool("isRunning", false);

                //Play jumping animation
                anim.SetBool("isJumping", true);

                //Play dust burst particle
                animatorFunctions.PlayParticle_1();
            }
        }
    }

    private void OnDrawGizmosSelected() //Draw gizmo
    {
        Gizmos.color = Color.yellow; //Set gizmo color to yellow
        Gizmos.DrawWireSphere(feet.transform.position, feetRadius); //Draw a gizmo circle with centre is feet position and the radius is feetRadius
    }


    public IEnumerator Flash()
    {
        int temp = 0;
        isHurt = false;
        while (temp < howManyTimeToFlash)
        {
            isHurt = true;
            sprite.color = flashingColor;
            yield return new WaitForSeconds(flashDuration);
            sprite.color = defaultColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        isHurt = false;
    }



    ////////////////////////////// OBSOLETE //////////////////////////////
    ///Obsolate due to animation not flipping (?)
    ///Would use transform equal new Vector and tweak the y rotation value

    //void Flip()
    //{
    //    isFacingRight = !isFacingRight;

    //    Vector2 scaler = transform.localScale;

    //    scaler.x *= -1;

    //    transform.localScale = scaler;
    //}
}
