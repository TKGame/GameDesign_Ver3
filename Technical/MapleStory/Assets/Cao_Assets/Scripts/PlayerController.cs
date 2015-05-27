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
    public float distance;//khoang cach nhay
    private Vector3 posMousePoint = new Vector3();//vi tri cua chuot theo Screen
    private Vector3 posRaycastPoint = new Vector3();//vi tri cua raycast theo Screen
    private bool isMove;// bien di chuyen
    private bool isMouse;// khi duoc Click
    private RaycastHit2D rayCast;
    private Vector3 posPlayerStart = new Vector3();
    private BattleCameraMovement cameraMovement;
	// Use this for initialization
	void Start () {
        posPlayerStart = transform.position;
        cameraMovement = GameObject.Find("Canvas").GetComponentInChildren<BattleCameraMovement>();
        if (cameraMovement == null)
        {
            Debug.Log("Chua lay duoc CameraMovement");
        }
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        Move();
	}
#if LOI
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
    Vector3 pos = new Vector3();
    void MovePlayer()
    {        
        
        //Debug.Log("POS PLayer = " + gameObject.transform.position);

        pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            
            rectPlayer = gameObject.transform;
            //Debug.Log("Rect Player = " + rectPlayer.position);
            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(worldPoint);
            //rayCat = Physics2D.Raycast(worldPoint, Vector3.one);
            posMouse = Input.mousePosition;
            //Debug.Log("Pos Mouse = " + worldPoint);
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
        Debug.Log("Camera = " + pos);
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
        //Debug.Log("Dis = " + _dis);
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
#endif

    //quay huong di chuyen cua Player
    void Flip()
    {
        
        facingRight = !facingRight;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //tim goc giua 2 diem
    // gia tri tra ve la 1 goc
    float AngleRotation(Vector3 posBegin, Vector3 posEnd)
    {
        Vector3 relative = posEnd - posBegin;
        float angle1 = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle1;
    }

    //ham nhay va xet trigger khi nhay
    void Jump()
    {
        if (isJumb == true && isMouse == true && rigid.velocity.y == 0)
        {
            rigid.AddForce(new Vector2(1.0f, jumpForce));
            isMouse = false;
        }
        if (rigid.velocity.y >= 0 && isJumb == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            isJumb = false;
        }
        if(rigid.velocity.y < 0 && grounded == false)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            
            
        }
       
    }

    //kiem tra khoang cach giua 2 diem
    //so sanh voi khoang cach di chuyen
    bool DistanceClickMouse(Vector3 _posPlayer, Vector3 _posMouse)
    {
        float _dis = Vector3.Distance(_posPlayer, _posMouse);
        //Debug.Log("Dis = " + _dis);
        if (_dis < distance)
            return true;
        return false;
    }
   
    //ham di chuyen cua player
    void Move()
    {
        Vector3 pos = cameraMovement.GetPosTouch();
        
        Vector3 posPlayerPoint = Camera.main.WorldToScreenPoint(transform.position);//vi tri player theo Screen
        if (Input.GetMouseButtonDown(0))
        {
            posMousePoint = Input.mousePosition;
            Debug.Log(System.String.Format("Pos Touch Camera Moment = {0}", pos));
            Debug.Log(System.String.Format("Pos Touch Mouse = {0}", posMousePoint));
            isMove = true;
            if (grounded == true)
                isMouse = true;
            if (posPlayerPoint.x < posMousePoint.x && !facingRight)
            {
                Flip();
            }
            if (posPlayerPoint.x > posMousePoint.x && facingRight)
            {
                Flip();
            }
        }
        if (isMouse == true)
        {
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(posMousePoint);//vi tri chuot theo Word
            Vector3 direction = posMouse - transform.position;

            rayCast = Physics2D.Raycast(posMouse, Vector3.down, 1.5f);//chieu tia Raycast
            posRaycastPoint = Camera.main.WorldToScreenPoint(rayCast.point);//vi tri rayCast theo Screen

            if (rayCast.collider != null && rayCast.collider.gameObject.tag == "Ground" )
            {
                if (posMousePoint.y > posPlayerPoint.y && grounded == true)
                    isJumb = true;
                
            }
        }
        //Debug.Log(System.String.Format("Pos RayCast = {0}", posRaycastPoint));

        float angle = AngleRotation(posPlayerPoint, posMousePoint);
        
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        if (x <= 0.02 && x >= -0.02)
        {
            isMove = false;
            _animator.SetBool("isMove", false);
        }
        posMousePoint.z = 0;
        if (isMove == true)
        {
           
            _animator.SetBool("isMove", true);
            transform.localPosition += new Vector3(x, 0, 0);
            //transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, speed * Time.deltaTime);
            
        }
        if (DistanceClickMouse(posPlayerPoint, posMousePoint))
            Jump();//nhay
    }
    
}
