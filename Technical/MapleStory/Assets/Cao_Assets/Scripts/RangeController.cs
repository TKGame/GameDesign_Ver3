using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeController : MonoBehaviour {

	// Use this for initialization
    public List<GameObject> listTaget;

    void Awake()
    {
        listTaget = new List<GameObject>();
    }
    // Use this for initialization
    void Start()
    {
        //GameObject parent = transform.parent.gameObject;

        //if (parent != null)
        //{
           
        //    if (parent.tag == "Enemy")
        //    {
        //        parentController = (EnemyController)parent.GetComponent<EnemyController>();
        //    }
        //    else
        //        if (parent.tag == "Boss")
        //        {
        //            parentController = (BossLv1Controller)parent.GetComponent<BossLv1Controller>();
        //        }
        //    if (parentController != null)
        //    {
        //        Debug.Log("Get BaseController" );
        //    }

        //}

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < listTaget.Count; i++)
        {
            if (listTaget[i] == null)
            {
                listTaget.Remove(listTaget[i]);
            }
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss")
        {
            if (!listTaget.Contains(other.gameObject))
            {
                listTaget.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss")
        {
            listTaget.Remove(other.gameObject);
        }
    }
}
