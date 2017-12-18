using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlController : MonoBehaviour {

    private enum GirlState {
        Idle, Walk, Follow, Talk, Reset
    }

    private GirlState state = GirlState.Idle;
    private Animator aniController = null;
    //private Transform previousFrameTransform = null;
    private Rigidbody mRigidbody;

    public girlController tail = null;
    //static private float safeDistance = 5.0f;
    private pathQueue pq = new pathQueue();

    private GameManager manager;

    // Use this for initialization
    void Start() {
        state = GirlState.Idle;
        //aniController.SetInteger("State", (int)GirlState.Idle);
    }

    private void Awake()
    {
        mRigidbody = this.GetComponent<Rigidbody>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        switch (state) {
            case GirlState.Idle:
                break;
            case GirlState.Follow:
                break;
            case GirlState.Reset:
                break;
            case GirlState.Talk:
                break;
            case GirlState.Walk:
                break;
            default:
                break;
        }
    }

    public void Follow(Vector3 previousVelocity) {
        Debug.Log(previousVelocity);

        mRigidbody.velocity = previousVelocity;

        //Vector3 followDirection = previousTransform.forward;

        //this.transform.position = previousTransform.position + followDirection * safeDistance;
        //this.transform.rotation = previousTransform.rotation;

        if (tail != null) {
            tail.Follow(pq.oneInoneOut(previousVelocity));
            //tail.Follow(previousFrameTransform);
        }

        //previousFrameTransform = this.transform;
    }

    public void HitByBullet()
    {
        switch (state) {
            case GirlState.Idle:
                changeState(GirlState.Follow);
                break;
            case GirlState.Follow:
                break;
            case GirlState.Reset:
                break;
            case GirlState.Talk:
                changeState(GirlState.Follow);
                break;
            case GirlState.Walk:
                changeState(GirlState.Follow);
                break;
            default:
                break;
        }
    }

    public void HitByBullet2()
    {
        manager.sanDown();
        this.gameObject.SetActive(false);
    }



    private void changeState(GirlState toThatState) {
        state = toThatState;
        //aniController.SetInteger("State", (int)toThatState);

        switch (toThatState) {
            case GirlState.Idle:
                break;
            case GirlState.Follow:
                manager.registerTail(this);
                break;
            case GirlState.Reset:
                break;
            case GirlState.Talk:
                break;
            case GirlState.Walk:
                break;
            default:
                break;
        }
    }

    public void concatenate(girlController con) {
        tail = con;
        tail.transform.position = this.transform.position;
    }
}
