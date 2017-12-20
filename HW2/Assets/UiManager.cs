using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Image SanImage;
    public Image LoveImage;
    public Image BloodImage;

    private float alpha = 0.5f;

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

    public void BeHit()
    {
        StartCoroutine("fadeOutEffect");
    }

    private IEnumerator fadeOutEffect() {
        //Debug.Log("start fade out");
        BloodImage.enabled = true;
        //Debug.Log("start fade out");
        for (float i = 0.5f; i > 0.0f; i -= Time.deltaTime / 2.0f)
        {
            //Debug.Log(i);
            BloodImage.color = new Color(1, 0, 0, i);
            yield return null;
        }
        //Debug.Log("start fade out");
        BloodImage.color = new Color(1, 0, 0, 0);
        BloodImage.enabled = false;
    }
}
