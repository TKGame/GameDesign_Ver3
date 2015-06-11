using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public PlayerController playerControll;
    public bool isRight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
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
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerControll.isMove = false;
        Debug.Log("Button Up");
        //throw new System.NotImplementedException();
    }
}
