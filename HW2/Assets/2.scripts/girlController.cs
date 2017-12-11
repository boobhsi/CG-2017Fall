using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlController : MonoBehaviour {

    private enum GirlState {
        Idle, Walk, Follow, Talk, Reset
    }

    private GirlState state = GirlState.Idle;
    private Animator aniController = null;
    private Transform previousFrameTransform = null;

    public girlController tail = null;
    static private float safeDistance = 5.0f;
    

	// Use this for initialization
	void Start () {
        state = GirlState.Idle;
        //aniController.SetInteger("State", (int)GirlState.Idle);
	}
	
	// Update is called once per frame
	void Update () {
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

    public void Follow(Transform previousTransform) {

        Vector3 followDirection = previousTransform.forward;

        this.transform.position = previousTransform.position + followDirection * safeDistance;
        this.transform.rotation = previousTransform.rotation;

        if (tail != null) {
            tail.Follow(previousFrameTransform);
        }

        previousFrameTransform = this.transform;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("bullet")) {
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
    }

    private void changeState(GirlState toThatState) {
        state = toThatState;
        //aniController.SetInteger("State", (int)toThatState);

        switch (toThatState) {
            case GirlState.Idle:
                break;
            case GirlState.Follow:
                GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
    }
}
