using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	public GameObject effect;//特效

	void Start () {
        //Destroy(gameObject, 3);
    }	
	void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("grils") || other.gameObject.CompareTag("chao"))
        {
            other.gameObject.SendMessage("HitByBullet", SendMessageOptions.DontRequireReceiver);
            Instantiate(effect, transform.position, transform.rotation);
            //Destroy(gameObject);//刪除砲彈
        }

        Destroy(gameObject);//刪除砲彈
    }
}
