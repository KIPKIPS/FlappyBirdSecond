using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Bird : MonoBehaviour {
    public Material mat;
    public int frameCount;

    public int fps;
    private float temp;

    public Rigidbody rigid;
    //public event Action KnockTrap; //声明一个事件,发布消息
    //public CameraController cc;

    public GameManager.GameState state;

    // Start is called before the first frame update
    void Start() {
        //设置默认状态
        state = GameManager._instance.currentState;
        mat = GetComponent<Renderer>().material;
        frameCount = 0;
        temp = 0;
        rigid = GetComponent<Rigidbody>();
        //cc = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update() {
        state = GameManager._instance.currentState;
        Vector3 v = rigid.velocity;
        //菜单状态
        if (state == GameManager.GameState.MENU) {
            rigid.useGravity = false;
        }
        //游戏中
        if (state == GameManager.GameState.RUNNING) {
            rigid.useGravity = true;
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


    }

    //发生碰撞
    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Trap") {
            //KnockTrap += cc.StopMove;//注册方法
            //KnockTrap?.Invoke();//不为NULL则调用
            //将状态设置为END
            GameManager._instance.SetState(GameManager.GameState.END);
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Score") {
            GameManager._instance.score++;
            GameObject.Find("Score").transform.GetComponent<Text>().text = "Your Score : " + GameManager._instance.score;
        }
    }
}
