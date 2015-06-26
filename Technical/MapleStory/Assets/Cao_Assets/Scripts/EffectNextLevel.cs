using UnityEngine;
using System.Collections;

public class EffectNextLevel : MonoBehaviour {

    private SpriteRenderer sprite;
    public float colorA = 1;
	// Use this for initialization
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
        SetEffect();
	}
    float _a = 0;
    public bool active;
    void SetEffect()
    {
        if (sprite != null && active == true)
        {
            _a += colorA;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, _a) * Time.deltaTime;
        }
    }
    public bool Finish()
    {
        if (_a == 255)
        {
            _a = 0;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, _a);
            active = false;
            return true;
        }
        return false;
    }
}
