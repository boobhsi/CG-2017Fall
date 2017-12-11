using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaoController : MonoBehaviour {

    public GameObject followed = null;
    public float speed = 2.0f;
    private Rigidbody mRigidBody;

	// Use this for initialization
	void Start () {
        mRigidBody = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate()
    {
        if (followed != null)
        {
            Vector3 direction = (followed.transform.position - this.transform.position).normalized;
            mRigidBody.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("grils")) {
            followed = other.gameObject;
        }
    }
}
