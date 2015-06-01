using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public PlayerController playerControll;

    //public float HPorMana;
    private float HporManaStart;
    public bool boolHP;
    private Image imageFill;

	// Use this for initialization
	void Start () {
        imageFill = GetComponent<Image>();
        if (playerControll != null)
        {
            if(boolHP)
            {
                HporManaStart = playerControll.HP;
            }
            else
            {
                HporManaStart = playerControll.Mana;
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    [ContextMenu("Test")]
    void Test()
    {
        ChangleHPFillAmountImage(100);
        
    }
    public void ChangleHPFillAmountImage(float HPorMana)
    {
        if (imageFill != null)
        {
            imageFill.fillAmount =  HPorMana * 1 / HporManaStart;
        }
    }
    public void ChangleManaFillAmountImage(float _mana)
    {
        
    }

}
