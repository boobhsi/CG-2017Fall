using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public tankMove player = null;
    public bool following = false;
    public UiManager ui;

    private girlController mTail;

    private float san = 1.0f;
    private float love = 0.0f;
    private float ultimate = 0.0f;

    private float sanDownValue = 0.1f;
    private float loveUpValue = 0.1f;
    private float loveConsume = 0.05f;
    private float loveDownValue = 0.1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void registerTail(girlController tail) {
        if (!following)
        {
            player.register(tail);
            mTail = tail;
            following = true;
        }
        else {
            mTail.concatenate(tail);
            mTail = tail;
        }
        love += loveUpValue;
        ui.SendMessage("SetLove", love, SendMessageOptions.DontRequireReceiver);
    }

    public void beenCatch() {
        player.cutOne();
        downSan();
        downLove();
    }

    public void sanDown() {
        downSan();
    }

    private void downSan() {
        san -= sanDownValue;
        ui.SendMessage("SetSan", san, SendMessageOptions.DontRequireReceiver);
        ui.SendMessage("BeHit", SendMessageOptions.DontRequireReceiver);
    }

    public bool consumeLove() {
        float temp = love - loveConsume;
        if (temp < 0.0f)
        {
            return false;
        }
        else {
            love = temp;
            ui.SendMessage("SetLove", love, SendMessageOptions.DontRequireReceiver);
            return true;
        }
    }

    private void downLove() {
        love -= loveDownValue;
        love = Mathf.Clamp(love, 0.0f, 1.0f);
        ui.SendMessage("SetLove", love, SendMessageOptions.DontRequireReceiver);
    }
}
