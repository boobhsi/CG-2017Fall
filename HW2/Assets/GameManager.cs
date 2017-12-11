using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public tankMove player = null;
    public bool following = false;

    private girlController mTail;

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
    }
}
