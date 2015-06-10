using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour {

    public BaseEnemyScripts enemyControll;

    private float health;
    private Image imageFill;
    private float hpStart;
	// Use this for initialization
	void Start () {
        //imageFill = GetComponent<Image>();
        hpStart = enemyControll.HP;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHealthEnemy();
	}
    void UpdateHealthEnemy()
    {
        health = enemyControll.HP;
        if (enemyControll != null)
        {
            if (health >= 0)
                gameObject.transform.localScale = new Vector3(health * 1 / hpStart, 1, 1);
        }
    }
}
