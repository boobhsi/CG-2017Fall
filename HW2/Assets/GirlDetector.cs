using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlDetector : MonoBehaviour {

    private chaoController parentScript;
    private SphereCollider mCollider;

    // Use this for initialization
    void Start () {
        
	}

    private void Awake()
    {
        parentScript = this.transform.parent.GetComponent<chaoController>();
        mCollider = this.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnEnable()
    {
        mCollider.enabled = true;
    }

    private void OnDisable()
    {
        mCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        parentScript.registerFollow(other.gameObject);
    }
}
