using UnityEngine;
using System.Collections;

public class dead : MonoBehaviour {
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

        if (collision.gameObject.tag == "bullet")
        {//當撞到的collider具有enemy tag時
            health = health - 10;
            if (health <= 0)
            {
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "bullet2")
        {//當撞到的collider具有enemy tag時
            health = health - 20;
            if (health <= 0)
            {
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
