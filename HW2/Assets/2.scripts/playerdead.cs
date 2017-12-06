using UnityEngine;
using System.Collections;

public class playerdead : MonoBehaviour {
    public float health = 100;
    public GameObject effect;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {//碰撞發生時呼叫
     //碰撞後產生爆炸

        if (collision.gameObject.tag == "enemy")
        {//當撞到的collider具有enemy tag時
            health = health - 10;
            if (health <= 0)
            {
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        
    }
}
