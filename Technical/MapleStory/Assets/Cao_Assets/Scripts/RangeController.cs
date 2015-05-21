using UnityEngine;
using System.Collections;

public class RangeController : MonoBehaviour {

	// Use this for initialization
    private EnemyController parentController;

    // Use this for initialization
    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        if (parent != null)
        {
           
            if (parent.tag == "Enemy")
            {
                parentController = (EnemyController)parent.GetComponent<EnemyController>();
            }
            else
                if (parent.tag == "Boss")
                {
                    parentController = (BossLv1Controller)parent.GetComponent<BossLv1Controller>();
                }
            if (parentController != null)
            {
                Debug.Log("Get BaseController" );
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (parentController != null)
        {
            if (other.tag == "Player")
            {
                parentController.isMove = true;
            }            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
