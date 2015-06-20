using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BattleCameraMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform battleCamera;
    public GameObject player;
    public PlayerController playerControl;
    public GameController gameController;
    public RectTransform canvasWorldTrans;

    private bool isTouch;
    public Vector3 pointTouch;
    private Vector3 posTouch;

    public CowdownSkill cowdownFire;
    public CowdownSkill cowdownTele;
    public CowdownSkill cowdownArrow;
	// Use this for initialization
	void Start () {
        posTouch = player.transform.position;
        //Debug.Log("Start Battle Camera Movement");
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null) 
        {
            MoveCameraByPlayer();
            ManaSkill();
            //playerControl.MoveToTarget(posTouch);
        }
      
       
	}

    void MoveCameraByPlayer() 
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        //SetLimitCamera(0, 3, 0, 0);        
        MoveCamera();
        LimitCamera();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player)
        {
            playerControl.isMouse = true;
            //Vector3 pointPlayerInCamera = battleCamera.GetComponent<Camera>().WorldToScreenPoint(player.transform.position);
            //pointPlayerInCamera.z = 0;

            //Position of touch in canvas wolrd 
            Vector3 pointTouchInPlayer;
           // Vector2 pointTouchInPlayer2;
            isTouch = RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasWorldTrans, eventData.position, battleCamera.GetComponent<Camera>(), out pointTouchInPlayer);
            //isTouch = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasWorldTrans, eventData.position, battleCamera.GetComponent<Camera>(), out pointTouchInPlayer2);
            posTouch = pointTouchInPlayer;
            //Debug.Log(System.String.Format("Point Vecter 2 = {0}",pointTouchInPlayer2));
            //Goi ham move Player toi target
            //playerControl.MoveToTarget(pointTouchInPlayer);

            //Debug.Log(posTouch);
            //player.transform.position = pointTouchInPlayer;
            //player.transform.position = pointTouch;
            //Debug.Log(System.String.Format("Point touch = {0} --- Point Touch = {1}", pointTouchInPlayer, eventData.position));
        } 
        else
        {
            Debug.Log("Not found pointer why player not exist");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Pointer Up - Move move");
    }

    //void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}

    //void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}
    public Vector3 GetPosTouch()
    {
        
        return posTouch;
    }

    // khi nhan button danh thuong
    public void AttackSkillDeffault()
    {
        playerControl.AttackSkillDefault();
        
    }
    //khi nhan button skill Fire
    public void AttackSkillFire()
    {
        if (playerControl.finishSkillFire == false)
            if (playerControl.Mana >= playerControl.manaSkillFire)//kiem tra xem con du mana dung Skill khong
            {
                cowdownFire.active = true;
                if (CheckSkillCowdown(cowdownFire) && cowdownFire.active == true)//kiem tra cowdown
                    playerControl.SkillFire(); //thuc hien Skill                
            }                   
    }
    //khi nhan button skill Tele
    public void AttackSkillTele()
    {
        if (playerControl.finishSkillFire == false)
            if (playerControl.Mana >= playerControl.manaSkillTele)
            {
                cowdownTele.active = true;
                if (CheckSkillCowdown(cowdownTele) && cowdownTele.active == true)
                    playerControl.SkillTeleportation();
            }
            
            
    }
    //khi nhan button skill Arrow
    public void AttackSkillArrow()
    {
        if (playerControl.finishSkillFire == false)
            if (playerControl.Mana >= playerControl.manaSkillArrow)
            {
                cowdownArrow.active = true;
                if (CheckSkillCowdown(cowdownArrow) && cowdownArrow.active == true)
                    playerControl.SkillArrowIce();
            }
            
            
    }
    //kiem tra xem skill da cowdown xong chua
    bool CheckSkillCowdown(CowdownSkill typeSkill)
    {
        if (typeSkill.SkillCowdown())
        {
            typeSkill.ResetTimeCountdown(); //time cowdow ve ban dau
            return  true;
        }
        return false;
    }
    void ManaSkill()
    {
        if (playerControl.Mana < playerControl.manaSkillArrow)
        {
            cowdownArrow.active = false;
        }
        if (playerControl.Mana >= playerControl.manaSkillArrow)
        {
            cowdownArrow.active = true;
        }
        if (playerControl.Mana < playerControl.manaSkillFire)
        {
            cowdownFire.active = false;
        }
        if (playerControl.Mana >= playerControl.manaSkillFire)
        {
            cowdownFire.active = true;
        }
        if (playerControl.Mana < playerControl.manaSkillTele)
        {
            cowdownTele.active = false;
        }
        if (playerControl.Mana >= playerControl.manaSkillTele)
        {
            cowdownTele.active = true;
        }
    }
    public void Jumb()
    {
        playerControl.Jumb();
    }
    public void Move()
    {
        //playerControl.Move();
    }
    private float posMinXCamera;
    private float posMaxXCamera;
    private float posMinYCamera;
    private float posMaxYCamera;
    public void SetLimitCamera(float _posMinXCamera, float _posMaxXCamera, float _posMinYCamera, float _posMaxYCamera)
    {
        posMinXCamera = _posMinXCamera;
        posMaxXCamera = _posMaxXCamera;
        posMinYCamera = _posMinYCamera;
        posMaxYCamera = _posMaxYCamera;
    }
    void LimitCamera()
    {
        battleCamera.position = new Vector3(Mathf.Clamp(battleCamera.position.x, posMinXCamera, posMaxXCamera), Mathf.Clamp(battleCamera.position.y, posMinYCamera, posMaxYCamera), battleCamera.position.z);
    }
    void MoveCamera()
    {
        //battleCamera.position = new Vector3(player.transform.position.x, Mathf.Lerp(battleCamera.position.y, player.transform.position.y, 1),battleCamera.position.z);
        battleCamera.position = new Vector3(player.transform.position.x, player.transform.position.y, battleCamera.position.z);

    }

}
