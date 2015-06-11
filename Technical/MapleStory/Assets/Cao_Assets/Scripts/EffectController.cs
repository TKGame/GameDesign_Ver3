using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectController : MonoBehaviour {

    public List<Sprite> listNumber;
    public List<SpriteRenderer> listSprite;
    public GameObject effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void InstanceEffectHit()
    {
        GameObject _effect = Instantiate(effect, Vector3.zero, Quaternion.identity) as GameObject;
    }


    //Test
    public int damge;
    [ContextMenu("Test")]
    void Test()
    {
        LayGiaTriDamge(damge);
    }
    void LayGiaTriDamge(int _damge)
    {
        int hangDonvi = 0;
        int hangChuc = 0;
        int hangTram = 0;
        int hangNghin = 0;

        if (_damge < 9999)
        {
            int mod = -1;
            List<int> dayso = new List<int>();
            int count = 0;

            while (_damge / 10 > 0)
            {
                
                mod = (int)_damge % 10;
                _damge = _damge / 10;
                //if(_damge > 0)
                //    dayso.Add((int)_damge);
                dayso.Add(mod);
                
                
                count++;
                Debug.Log("count = " + count);
            }
            //dayso.Add((int)_damge);
            for(int i = dayso.Count - 1;i>= 0; --i)
            {
                Debug.Log(System.String.Format("Day so phan tu i = {0}", dayso[i]));
            }
        }
    }
    
}
