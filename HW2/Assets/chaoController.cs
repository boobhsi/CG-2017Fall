using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaoController : MonoBehaviour {

    public GameObject followed = null;
    public float speed = 2.0f;
    private Rigidbody mRigidBody;
    private BoxCollider selfCollider;
    
    public GameObject mDetector;
    public GameObject mContactor;

    private GameManager manager;

    // Use this for initialization
    void Start () {

    }

    void OnEnable()
    {
        speed = 2.0f;
        followed = null;
        mDetector.SetActive(true);
        mContactor.SetActive(true);
    }

    void Awake() {
        mRigidBody = this.GetComponent<Rigidbody>();
        selfCollider = this.GetComponent<BoxCollider>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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

    public void registerFollow(GameObject fol) {
        followed = fol;
    }

    public void disableChao() {
        mContactor.SetActive(false);
        mDetector.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        selfCollider.enabled = false;
    }

    public void HitByBullet()
    {
        manager.sanDown();
        this.gameObject.SetActive(false);
    }

    public void HitByBullet2()
    {
        //manager.sanDown();
        this.gameObject.SetActive(false);
    }
}
