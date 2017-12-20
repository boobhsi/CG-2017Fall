using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion2 : MonoBehaviour {

    public GameObject effect;//特效

    void Start()
    {
        //Destroy(gameObject, 3);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ddd");
        if (other.gameObject.CompareTag("grils") || other.gameObject.CompareTag("chao"))
        {
            other.gameObject.SendMessage("HitByBullet2", SendMessageOptions.DontRequireReceiver);
            Instantiate(effect, transform.position, transform.rotation);
            //Destroy(gameObject);//刪除砲彈
        }

        Destroy(gameObject);//刪除砲彈
    }
}
