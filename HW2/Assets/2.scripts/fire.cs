﻿using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

	public Rigidbody projcetile;
	float speed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //獲取Ctrl與滑鼠左鍵的按鍵
        //判斷是否按下按鍵
        if (Input.GetButtonDown("Fire1"))
        {
            //產生砲彈在發射點
            Rigidbody shoot =
                (Rigidbody)Instantiate(projcetile, transform.position, transform.rotation * Quaternion.Euler(0, 90, 90));
            //給砲彈方向力，將他從y軸推出去
            shoot.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
            //讓坦克的碰撞框忽略砲彈的碰撞框
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());

        }
	}
}
