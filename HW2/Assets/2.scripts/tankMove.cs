using UnityEngine;
using System.Collections;

public class tankMove : MonoBehaviour {
    
	public float mSpeed = 1;
	public float rSpeed = 1;
    public float maxSpeed;

    public girlController first = null;

    private Rigidbody mRigidBody;
    public Transform tailTransform;
    //private Transform previousFrameTransform;

    private pathQueue pq = new pathQueue();

	// Use this for initialization
	void Start () {
        mRigidBody = this.GetComponent<Rigidbody>();
        //previousFrameTransform = tailTransform;
	}

	// Update is called once per frame
	void Update () {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(0, rSpeed * h, 0);
        //mRigidBody.AddRelativeForce(new Vector3(0.0f, 0.0f, -v * mSpeed));

        if (first != null)
        {
            first.Follow(pq.oneInoneOut(mRigidBody.velocity));
            //first.Follow(previousFrameTransform);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        mRigidBody.AddRelativeForce(new Vector3(0.0f, 0.0f, -v * mSpeed));
        //mRigidBody.velocity = mRigidBody.velocity / mRigidBody.velocity.magnitude * maxSpeed; //clamping
    }

    public void register(girlController gc) {
        first = gc;
        gc.gameObject.transform.position = tailTransform.position;
    }

    public void cutOne() {
        if (first != null)
        {
            GameObject temp = first.gameObject;
            temp.SetActive(false);
            first = first.tail;
        }
    }
}
