using UnityEngine;
using System.Collections;

public class PlayerController : BaseGameObject {

    public float Mana;
    private bool facingRight = true;
    private bool isJumb = false;
    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public GameObject boxJump;
    public Transform groundCheck;
    public HealthController healthController;
    public HealthController manaController;
    private bool grounded = false;
    public float distance;//khoang cach nhay
    private Vector3 posMousePoint = new Vector3();//vi tri cua chuot theo Screen
    private Vector3 posRaycastPoint = new Vector3();//vi tri cua raycast theo Screen
    private bool isMove;// bien di chuyen
    public bool isMouse;// khi duoc Click
    private RaycastHit2D rayCast;
    private Vector3 posPlayerStart = new Vector3();
    private BattleCameraMovement cameraMovement;
    private bool attackSkill;
    private RangeController rangeControll;

	// Use this for initialization
	void Start () {
        rangeControll = gameObject.GetComponentInChildren<RangeController>();
        attackSkill = false;
        posPlayerStart = transform.position;
        cameraMovement = GameObject.Find("Canvas").GetComponentInChildren<BattleCameraMovement>();
        if (cameraMovement == null)
        {
            Debug.Log("Chua lay duoc CameraMovement");
        }
        if (rigid == null)
        {
            Debug.Log("K the get lay Rigidbody");
        }
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (healthController != null)
        {
            healthController.ChangleHPFillAmountImage(HP);
        }
	}
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

    //kiem tra khoang cach giua 2 diem
    //so sanh voi khoang cach di chuyen
    bool DistanceClickMouse(Vector3 _posPlayer, Vector3 _posMouse)
    {
        float _dis = Mathf.Abs(_posMouse.x - _posPlayer.x);
        if (_dis < distance)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Khi người chơi touch trên màn hình, thì mới gọi MoveTarget
    /// Lúc này lấy được vị trí Touch - Vị trí người chơi(Tọa độ ở Canvas Wolrd). 
    /// Sau đó vẽ Raycast và tính toán logic
    /// </summary>
    /// <param name="posTarget"> Pos truyền vào là pos ở Canvas World Space</param>
    public void MoveToTarget(Vector3 posTarget) 
    {
        MovePlayer(posTarget);

    }
    //di chuyen player
    void MovePlayer(Vector3 _posTouch)
    {
        float angle = AngleRotation(transform.position, _posTouch);

        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        if (finishSkillFire == false)
            transform.localPosition += new Vector3(x, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, _posTouch, 0.1f);
        if (isMouse == true)
        {
            
            if (transform.position.x <= _posTouch.x && !facingRight)
            {
                Flip();
            }
            if (transform.position.x > _posTouch.x && facingRight)
            {
                Flip();
            }
        }
        if (isMouse == true && _posTouch.y < transform.position.y + 1)
        {
            isMouse = false;
        }
        if (isMouse == true && grounded && _posTouch.y >= transform.position.y + 1)
        {
            if (DistanceClickMouse(transform.position, _posTouch))
            {
                _animator.SetTrigger("isJump");
                isJumb = true;
                if (isJumb == true && Mathf.Abs(rigid.velocity.y) < 0.2f)
                {
                    JumpPlayer();
                }
            }
            
        }
        OnOffAnimatorMove(_posTouch);
        OnOffIsTrigger();
    }
    void OnOffAnimatorMove(Vector3 _pos)
    {
        if (Mathf.Abs(_pos.x - transform.position.x) >= 0.4f)
        {
            _animator.SetBool("isMove", true);
        }
        if (Mathf.Abs(_pos.x - transform.position.x) < 0.4f)
        {
            _animator.SetBool("isMove", false);
        }
    }
    //bat tat trigger cua player khi nhay
    void OnOffIsTrigger()
    {
        if (rigid.velocity.y >= 0 && isJumb == true)
        {
            
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (rigid.velocity.y < 0)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            isJumb = false;
        }
    }
    //nhay
    void JumpPlayer()
    {       
        rigid.AddForce(new Vector2(1.0f, jumpForce));
        isMouse = false;        
    }
    //bo sung mana va Hp cho Player
    public void AddHPandMana(float _hp, float _mana)
    {
        HP += _hp;
        Mana += _mana;
    }
    //skil danh thuong
    public void AttackSkillDefault()
    {
        Mana -= 10;
        if (manaController != null)
        {
            manaController.ChangleHPFillAmountImage(Mana);
        }
        _animator.SetTrigger("isAttack");
        for (int i = 0; i < rangeControll.listTaget.Count; i++)
        {
            EnemyController _enemy = rangeControll.listTaget[i].GetComponent<EnemyController>();
            if (_enemy != null)
            {
                _enemy.Hit(damge);                
            }
        }
        attackSkill = true;
    }
    public GameObject firePrefabs;
    public GameObject telePrefabs;
    public GameObject arrowPrefabs;
    private bool finishSkillFire;
    [ContextMenu("SkillFire")]
    public void SkillFire()
    {
        rangeControll.listTaget.Clear();
        finishSkillFire = true;
        GameObject _fire = Instantiate(firePrefabs, transform.position, Quaternion.identity) as GameObject;
        _fire.transform.SetParent(gameObject.transform);
        _fire.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        DeActiveRender();
    }
    void DeActiveRender()
    {
        
        SpriteRenderer _spritePlayer = gameObject.GetComponent<SpriteRenderer>();     
        if (_spritePlayer != null)
        {
            _spritePlayer.enabled = false;
        }
    }
    void ActiveRender()
    {
        SpriteRenderer _spritePlayer = gameObject.GetComponent<SpriteRenderer>();
        if (_spritePlayer != null)
        {
            _spritePlayer.enabled = true;
        }
    }
    [ContextMenu("SkillTeleportation")]
    public void SkillTeleportation()
    {
        rangeControll.listTaget.Clear();
        finishSkillFire = true;
        GameObject _fire = Instantiate(telePrefabs, transform.position, Quaternion.identity) as GameObject;
        _fire.transform.SetParent(gameObject.transform);
        _fire.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        _fire.transform.localRotation = Quaternion.Euler(0, 0, 0);
        DeActiveRender();

    }

    public Transform arrowTransform;
    [ContextMenu("SkillArrowTape")]
    public void SkillArrowTape()
    {
        rangeControll.listTaget.Clear();
        arrowTransform.position = transform.position;
        if (!facingRight)
        {
            arrowTransform.localScale = new Vector3(4, 4, 1);
        }
        else
        {
            arrowTransform.localScale = new Vector3(-4, 4, 1);
        }
        GameObject _fire = Instantiate(arrowPrefabs, transform.position, Quaternion.identity) as GameObject;
        _fire.transform.SetParent(arrowTransform);
        _fire.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        
    }
    public void ActiveSpriteRender()
    {
        finishSkillFire = false;
        ActiveRender();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
    }
}
