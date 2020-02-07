using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bird : MonoBehaviour
{
    public Material mat;
    public int frameCount;

    public int fps;
    private float temp;

    public Rigidbody rigid;
    public event Action KnockTrap;//声明一个事件,发布消息
    public CameraController cc;

    // Start is called before the first frame update
    void Start() {
        mat = GetComponent<Renderer>().material;
        frameCount = 0;
        temp = 0;
        rigid = GetComponent<Rigidbody>();
        cc = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 v = rigid.velocity;
        rigid.velocity = new Vector3(5, v.y, 0);//添加水平速度
        //Animation
        mat.SetTextureOffset(1, new Vector2(frameCount * 1 / 3.0f, 0));
        temp += 1.0f / fps;
        if (temp >= 1) {
            frameCount++;
            temp = 0;
        }
        frameCount %= 3;
        
        //Controller
        if (Input.GetMouseButtonDown(0)) {
            rigid.velocity = new Vector3(v.x, 5, 0);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.tag=="Trap") {
            Debug.Log("pz");
            KnockTrap += cc.StopMove;
            KnockTrap?.Invoke();//不为NULL则调用
        }
    }
}
