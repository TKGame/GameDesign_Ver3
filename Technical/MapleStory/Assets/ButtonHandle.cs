using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

    public PlayerController playerControll;
    public bool isRight;
    public bool isJumb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private bool isPress;
    private float speed = 5;
    public void OnPointerDown(PointerEventData eventData)
    {              
        if (isJumb == false)
        {
            Debug.Log("Is Press = " + isPress);
            if (isRight == true)
            {
                playerControll.speed = 5;
                if (!playerControll.facingRight)
                {
                    playerControll.Flip();
                }
            }
            else
            {
                if (playerControll.facingRight)
                {
                    playerControll.Flip();
                }
                playerControll.speed = -5;
            }
            playerControll.isMove = true;
            Debug.Log("Button Down");
        }
        else
        {
            if (playerControll != null)
                playerControll.Jumb();
        }
        //throw new System.NotImplementedException();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isJumb == false)
        {
            if (isRight == true)
            {
                playerControll.speed = 5;
                if (!playerControll.facingRight && playerControll.isMove)
                {
                    playerControll.Flip();
                }
            }
            else
            {
                if (playerControll.facingRight && playerControll.isMove)
                {
                    playerControll.Flip();
                }
                playerControll.speed = -5;
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isPress = false; 
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (isJumb == false)
        {
            playerControll.isMove = false;
            Debug.Log("Button Up");
        }
        else
        {
 
        }
        //throw new System.NotImplementedException();
    }
}
