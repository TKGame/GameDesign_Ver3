using UnityEngine;
using System.Collections;

public class PlayerController : BaseGameObject {

    public Transform transfBullet;
    private bool facingRight = true;
    private bool isJumb = false;
    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public GameObject boxJump;
    public Transform groundCheck;
    private bool grounded = false;
    private Vector3 posMouse;
    private bool isMove;
    private RaycastHit2D rayCat;
    private CheckBoxGround _checkBoxGround;
    
	// Use this for initialization
	void Start () {
        //rayCat = Physics2D.Raycast()
        posMouse = Vector3.zero;
        _checkBoxGround = gameObject.GetComponentInChildren<CheckBoxGround>();
	}
	
	// Update is called once per frame
	void Update () {
        //grounded = Physics2D.Linecast(transform.localPosition, groundCheck.localPosition, 1 << LayerMask.NameToLayer("Ground"));
        MovePlayer();
	}
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space) /*&& grounded*/)
        //{
        //    isJumb = true;
        //}
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //Move();
        //Shoot();
    }
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        _animator.SetFloat("speed", Mathf.Abs(h));
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        
        else if (h < 0 && facingRight)
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
    Transform rectPlayer = new RectTransform();
    Vector3 worldPoint = Vector3.one;
    void MovePlayer()
    {        
        Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //Debug.Log("POS PLayer = " + gameObject.transform.position);
        
       
        if (Input.GetMouseButtonDown(0))
        {
            rectPlayer = gameObject.transform;
            Debug.Log("Rect Player = " + rectPlayer.position);
            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(worldPoint);
            //rayCat = Physics2D.Raycast(worldPoint, Vector3.one);
            posMouse = Input.mousePosition;
            Debug.Log("Pos Mouse = " + worldPoint);
            isJumb = true;
            isMove = true;
            //if (rayCat.collider != null && rayCat.collider.gameObject.tag == "Ground")
            //    SetBoxCollider(rectPlayer, (RectTransform)rayCat.collider.gameObject.transform);
            if (pos.x < posMouse.x && !facingRight)
            {
                Flip();
            }
            if (pos.x > posMouse.x && facingRight)
            {
                Flip();                
            }
        }

        float angle = AngleRotation(pos, posMouse);
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        if (isMove == true )
        {
            transform.localPosition += new Vector3(x, 0, 0);
            if (DistanceClickMouse(rectPlayer, worldPoint))
                CheckJump(worldPoint);
            
        }
        
    }

    bool DistanceClickMouse(Transform _posPlayer, Vector3 _posMouse)
    {
        float _dis = Vector3.Distance(_posPlayer.localPosition, _posMouse);
        Debug.Log("Dis = " + _dis);
        if (_dis < 11)
            return true;
        return false;
    }
    void CheckJump(Vector3 posTouch)
    {
        for (int i = 0; i < _checkBoxGround.listBoxCheck.Count; i++)
        {
            if (posTouch.y > _checkBoxGround.listBoxCheck[i].y - 0.5 && posTouch.y < _checkBoxGround.listBoxCheck[i].y + 1.5)
            {
                if (posTouch.x > _checkBoxGround.listBoxCheck[i].x - 1 && posTouch.x < _checkBoxGround.listBoxCheck[i].x + 1)
                {
                      Jump();
                }
 
            }
        }
    }
    float AngleRotation(Vector3 posBegin, Vector3 posEnd)
    {
        Vector3 relative = posEnd - posBegin;
        float angle1 = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle1;
    }
    float AngleRotation1(RectTransform transfPlayer, RectTransform transfTouch)
    {
        Vector3 relative = new Vector3( (transfTouch.position.x - transfPlayer.position.x)/2,(transfTouch.position.y - transfPlayer.position.y )/ 2, 0);
        float angle1 = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle1;
    }
    float Distansd(RectTransform posPlayer, RectTransform posTouch)
    {
        float distans = 0;
        distans = Vector3.Distance(posPlayer.position, posTouch.position);
        return distans;
    }
    [ContextMenu("Jump")]

    void Jump()
    {
        if (isJumb == true)
        {
            Debug.Log("Player nhay");
            rigid.AddForce(new Vector2(0f, jumpForce));
            
        }
        if (rigid.velocity.y >= 0 && isJumb == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            
        }
        else
            if (rigid.velocity.y < 0)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        isJumb = false;
        
    }
    void Test()
    {
        
    }
    void SetBoxCollider(RectTransform transfPlayer, RectTransform transfTouch)
    {
        float lenght = Distansd(transfPlayer, transfTouch);
        float _rotation = AngleRotation1(transfPlayer, transfTouch);


        BoxCollider2D _boxJump = boxJump.GetComponent<BoxCollider2D>();
        if (_boxJump != null)
        {
            
            _boxJump.size = new Vector2(0.2f, lenght/2);
            
            boxJump.transform.position = new Vector3((transfPlayer.position.x + transfTouch.position.x) / 2, (transfPlayer.position.y + transfTouch.position.y)/ 2, 0);
            boxJump.transform.rotation = Quaternion.Euler(0, 0, -_rotation);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

    }
    void OnTriggerExit2D(Collider2D col)
    {

    }
}
