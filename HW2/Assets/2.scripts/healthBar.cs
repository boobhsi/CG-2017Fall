using UnityEngine;
using System.Collections;

public class healthBar : MonoBehaviour {
    public float maxHealth;
    public dead d;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        enemy = GameObject.Find("enemy");
        d = enemy.GetComponent<dead>();
    }
	
    void Awake()
    {
        
    }
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(-98 + 96 * d.health / maxHealth, 2f, 0f);
	}
}
