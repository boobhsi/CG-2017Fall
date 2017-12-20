using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwanser : MonoBehaviour {

    public GameObject prefab;
    public List<Transform> nodes;
    public int numLimit;
    public float rate;
    public int initialNum;

    private int num = 0;

	// Use this for initialization
	void Start () {
        num = initialNum;
        StartCoroutine("timer");
	}
	
	// Update is called once per frame
	void Update () {
	}

    private IEnumerator timer() {
        //Debug.Log("start fade out");
        generate();
        //Debug.Log("start fade out");
        for (float i = 1.0f; i > 0.0f; i -= Time.deltaTime / rate)
        {
            //Debug.Log(i);
            //BloodImage.color = new Color(1, 0, 0, i);
            yield return null;
        }
        //Debug.Log("start fade out");
        //BloodImage.color = new Color(1, 0, 0, 0);
        //BloodImage.enabled = false;
        StartCoroutine("timer");
    }

    private void generate() {
        if (num < numLimit) {
            Transform temp = nodes[(int)Random.Range(0.0f, (float)(nodes.Count))];
            Instantiate(prefab, temp.position, temp.rotation);
            num += 1;
        }
    }

    public void minusOne() {
        num -= 1;
    }
}
