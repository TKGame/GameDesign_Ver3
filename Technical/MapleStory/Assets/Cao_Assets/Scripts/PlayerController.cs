using UnityEngine;
using System.Collections;

public class PlayerController : BaseGameObject {

    public float Mana;
    public  bool facingRight = true;
    public bool isJumb = false;
    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public GameObject boxJump;
    public Transform groundCheck;
    public HealthController healthController;
    public HealthController manaController;
    public bool grounded = false;
    public float distance;//khoang cach nhay
    private Vector3 posMousePoint = new Vector3();//vi tri cua chuot theo Screen
    private Vector3 posRaycastPoint = new Vector3();//vi tri cua raycast theo Screen
    public bool isMove;// bien di chuyen
    public bool isMouse;// khi duoc Click
    private RaycastHit2D rayCast;
    private Vector3 posPlayerStart = new Vector3();
    private BattleCameraMovement cameraMovement;
    private bool attackSkill;
    private RangeController rangeControll;

    float HpStart;
    float manaStart;
	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //SetPosLimit(-7, 7, -5, 5);
        HpStart = HP;
        manaStart = Mana;
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
    private float timeAddHp = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Jumb();
        }
        PosLimit();
        Move();
        if (timeAddHp > 1)
        {
            //if (HP < HpStart)
            //    HP += 2;
            if (Mana  < manaStart)
                Mana += 1;
            timeAddHp = 0;
        }
        timeAddHp += Time.deltaTime;
        Die();
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));        
        UpdateManaAndHp();
	}
    //quay huong di chuyen cua Player
    public void Flip()
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
        
        float angle1;
        Vector3 relative = posEnd - posBegin;
      
        angle1 = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

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
        if (gameObject == null)
        {
            return;
        }
        float angle = AngleRotation(transform.position, _posTouch);
        //Debug.Log(System.String.Format("Angle = {0}", angle));
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        
        if (finishSkillFire == false)
        {
            if (Mathf.Abs(transform.position.x - _posTouch.x) > 0.2f)
                transform.position += new Vector3(x, 0, 0);          
            
        }
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
                    JumbPlayer();
                }
            }
            
        }
        OnOffAnimatorMove(_posTouch);
        OnOffIsTrigger();
    }

    public void SetFrameFinalAttack()
    {
        _animator.SetTrigger("stand");
    }

    public void Move()
    {
        OnOffIsTrigger();  
        if (isMove == true)
        {                 
            _animator.SetBool("isMove", true);            
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime; 
        }
        if (isMove == false)
        {
            _animator.SetBool("isMove", false);
        }
    }
    public void Jumb()
    {
        JumbPlayer(); 
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
        if (rigid.velocity.y >= 0 && isJumb == true && rigid.velocity.x == 0)
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
    void JumbPlayer()
    {        
        if (grounded &&  isJumb == false )
        {
            isJumb = true;      
            rigid.AddForce(new Vector2(1.0f, jumpForce));
        }
              
    }
    //bo sung mana va Hp cho Player
    public void AddHPandMana(float _hp, float _mana)
    {
        HP += _hp;
        Mana += _mana;
    }

    void UpdateManaAndHp()
    {
        if (healthController != null)
        {
            healthController.ChangleHPFillAmountImage(HP);
        }
        if (manaController != null)
        {
            manaController.ChangleHPFillAmountImage(Mana);//update thanh mana
        }
    }
    void AddManaSecond()
    {
 
    }
    //skil danh thuong
    public void AttackSkillDefault()
    {        
        
        _animator.SetTrigger("isAttack");
        for (int i = 0; i < rangeControll.listTaget.Count; i++)
        {
            //EnemyController _enemy = rangeControll.listTaget[i].GetComponent<EnemyController>();
            if (rangeControll.listTaget[i] == null)
            {
                return;
            }
            BaseEnemyScripts _enemy = rangeControll.listTaget[i].GetComponent<BaseEnemyScripts>();
            if (_enemy != null)
            {
                GameObject _effect = Instantiate(effectHit, new Vector3(rangeControll.listTaget[i].transform.position.x, rangeControll.listTaget[i].transform.position.y +1 , 0), Quaternion.identity) as GameObject;
                _effect.transform.SetParent(rangeControll.listTaget[i].transform);
                _effect.transform.localScale = Vector3.one;
                //_effect.transform.localPosition = new Vector3(rangeControll.listTaget[i].transform.position.x, rangeControll.listTaget[i].transform.position.y , 0);
                EffectController _effectControll = _effect.GetComponent<EffectController>();
                _effectControll.LayGiaTriDamge(damge);
                _enemy.Hit(damge);                
            }
        }
        attackSkill = true;
    }
    public GameObject firePrefabs;
    public GameObject telePrefabs;
    public GameObject arrowPrefabs;
    public Transform arrowTransform;
    public GameObject effectHit;
    public float manaSkillFire;
    public float manaSkillTele;
    public float manaSkillArrow;
    public bool finishSkillFire;
    
    //skil no lua
    public void SkillFire()
    {
        
        Mana -= manaSkillFire;//tru mana khi su dung skill
        finishSkillFire = true;
        GameObject _fire = Instantiate(firePrefabs, new Vector3(transform.position.x,transform.position.y + 1 ,0), Quaternion.identity) as GameObject;
        _fire.transform.SetParent(gameObject.transform);
        
        _fire.transform.localScale = new Vector3(1f, 1f, 1);
        DeActiveRender();
        
    }
    //tat nhan vat tren mam hinh
    void DeActiveRender()
    {        
        SpriteRenderer _spritePlayer = gameObject.GetComponent<SpriteRenderer>();     
        if (_spritePlayer != null)
        {
            _spritePlayer.enabled = false;
        }
        
    }
    //hien thi lai nhan vat tren man hinh
    void ActiveRender()
    {
        SpriteRenderer _spritePlayer = gameObject.GetComponent<SpriteRenderer>();
        if (_spritePlayer != null)
        {
            _spritePlayer.enabled = true;
        }
    }
   //skill toc bien
    public void SkillTeleportation()
    {
        Mana -= manaSkillTele;
        finishSkillFire = true;
        GameObject _fire = Instantiate(telePrefabs, transform.position, Quaternion.identity) as GameObject;
        _fire.transform.SetParent(gameObject.transform);
        _fire.transform.localScale = new Vector3(1f, 1f, 1);
        _fire.transform.localRotation = Quaternion.Euler(0, 0, 0);
        DeActiveRender();     

    }

    //Skill ban mui ten bang
    public void SkillArrowIce()
    {
        if (gameObject == null)
        {
            return;
        }
        Mana -= manaSkillArrow;
        finishSkillFire = true;
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
        _fire.transform.localScale = new Vector3(1f, 1f, 1);       
        
    }

    // khi su dung Skill thi tat nhan vat tren man hinh
    //khong cho di chuyen
    public void ActiveSpriteRender()
    {
        finishSkillFire = false;
        ActiveRender();
    }
    private float posMinX;
    private float posMaxX;
    private float posMinY;
    private float posMaxY;

    public void SetPosLimit(float _posMinX, float _posMaxX, float _posMinY, float _posMaxY)
    {
        posMinX = _posMinX;
        posMaxX = _posMaxX;
        posMinY = _posMinY;
        posMaxY = _posMaxY;        
    }
    void PosLimit()
    {
        //gameObject.transform.position = new Vector3(Mathf.Lerp(posMinX, posMaxX,Time.time), Mathf.Lerp(posMinY, posMaxY,Time.time), 0);
        gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, posMinX, posMaxX), Mathf.Clamp(transform.position.y, posMinY, posMaxY), 0);
    }
    public bool nextLevel = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Level")
        {
            nextLevel = true; 
        }        
    }
}
