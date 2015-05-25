using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BattleCameraMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform battleCamera;
    public GameObject player;

    public RectTransform canvasWorldTrans;

    private bool isTouch;
    public Vector3 pointTouch;
	// Use this for initialization
	void Start () {
        Debug.Log("Start Battle Camera Movement");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player)
        {
            Vector3 pointPlayerInCamera = battleCamera.GetComponent<Camera>().WorldToScreenPoint(player.transform.position);
            pointPlayerInCamera.z = 0;

            //Position of touch in canvas wolrd 
            Vector3 pointTouchInPlayer;
            isTouch = RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasWorldTrans, eventData.position, battleCamera.GetComponent<Camera>(), out pointTouchInPlayer);

            player.transform.position = pointTouchInPlayer;
            //player.transform.position = pointTouch;
            Debug.Log(System.String.Format("Point touch = {0} --- Point Touch = {1}", pointTouchInPlayer, eventData.position));
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
}
