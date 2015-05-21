using UnityEngine;
using System.Collections;

public class PlayerController : BaseGameObject {

    public Transform transfBullet;
    private bool facingRight = true;
    private bool isJumb = false;
    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    private Transform groundCheck;
    private bool grounded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) /*&& grounded*/)
        {
            isJumb = true;
        }
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        Move();
        Shoot();
    }
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        _animator.SetFloat("speed", Mathf.Abs(h));
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (h > 0 && facingRight)
        {
            Flip();
        }
        
        else if (h < 0 && !facingRight)
            Flip();
        if (isJumb)
        {
            _animator.SetTrigger("jumb");
            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, jumpForce));
            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            isJumb = false;
        }

    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (!facingRight)
            {
                GameObject _bullet = Instantiate(bullet, transfBullet.position, Quaternion.identity) as GameObject;
                _bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                GameObject _bullet = Instantiate(bullet, transfBullet.position, Quaternion.identity) as GameObject;
                _bullet.GetComponent<BulletController>().Flip();
            }

        }
    }
    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
