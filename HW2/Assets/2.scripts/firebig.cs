using UnityEngine;
using System.Collections;

public class firebig : MonoBehaviour {
    public Rigidbody projcetile;
    float speed = 20;
    private GameManager gm;
    // Use this for initialization
    void Start () {
	
	}

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            if (gm.consumeLove())
            {
                //產生砲彈在發射點
                Rigidbody shoot =
                    (Rigidbody)Instantiate(projcetile, transform.position, transform.rotation);
                //給砲彈方向力，將他從y軸推出去
                shoot.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
                //讓坦克的碰撞框忽略砲彈的碰撞框
                Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
            }
        }
    }
}
