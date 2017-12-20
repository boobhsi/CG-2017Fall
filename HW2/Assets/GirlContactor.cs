using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlContactor : MonoBehaviour {

    private chaoController parentScript;
    private GameManager gm;
    private BoxCollider mCollider;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        parentScript = this.transform.parent.GetComponent<chaoController>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        mCollider = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (other.gameObject.GetComponent<girlController>().beConnected) gm.beenCatch();
        else other.gameObject.SetActive(false);
        parentScript.disableChao();
        //gm.gameObject.SendMessage("beenCatch", SendMessageOptions.DontRequireReceiver);
    }
}
