using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Image SanImage;
    public Image LoveImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSan(float s) {
        Vector3 mT = SanImage.rectTransform.localScale;
        SanImage.rectTransform.localScale = new Vector3(mT.x, s, mT.z);
        Debug.Log("Now San: " + s);
    }

    public void SetLove(float l) {
        Vector3 mT = LoveImage.rectTransform.localScale;
        LoveImage.rectTransform.localScale = new Vector3(mT.x, l, mT.z);
        Debug.Log("Now Love: " + l);
    }
}
