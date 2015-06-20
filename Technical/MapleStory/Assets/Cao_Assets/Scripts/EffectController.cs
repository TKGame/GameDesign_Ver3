using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectController : MonoBehaviour {

    public List<Sprite> listNumber;
    public List<SpriteRenderer> listSprite;
    public GameObject effect;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 4; i++)
        {
            //listSprite[i].sprite = null;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (activeFinish == true)
        {
            gameObject.transform.position += new Vector3(0, 0.2f, 0) * Time.deltaTime;
            if (timeFinish > 3)
            {
                Destroy(gameObject);
            }
            timeFinish += Time.deltaTime;
        }
	}


    //Test
    public float damge;
    private float timeFinish;
    [ContextMenu("Test")]
    void Test()
    {
        LayGiaTriDamge(damge);
    }
    private bool activeFinish = false; 

    //lay gia tri damge nhan vao vao in ra man hinh
    public void LayGiaTriDamge(float _damge)
    {
        activeFinish = true;
        List<int> dayso = new List<int>();
        //tinh toan luong dam nhan vao
        if (_damge < 9999)
        {

            int mod = -1;            
            while ((int)_damge / 10 > 0)
            {
                
                mod = (int)_damge % 10;
                _damge = _damge / 10;
                dayso.Add(mod);
            }
            dayso.Add((int)_damge);           
        }
        int j = 0;

        // hien thi luong damge
        for (int i = dayso.Count - 1; i >= 0; --i)
        {
            listSprite[j].sprite = listNumber[dayso[i]];
            j++;
        }
        for (int i = 3; i > dayso.Count - 1; --i)
        {
            listSprite[i].sprite = null;
        }
    }
    
}
