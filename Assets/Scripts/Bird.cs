using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Material mat;
    public int frameCount;

    public int fps;
    private float temp;

    public Rigidbody rigid;
    // Start is called before the first frame update
    void Start() {
        mat = GetComponent<Renderer>().material;
        frameCount = 0;
        temp = 0;
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update() {
        rigid.velocity = new Vector3(5, 0, 0);//添加水平速度
        //控制帧动画
        mat.SetTextureOffset(1, new Vector2(frameCount * 1 / 3.0f, 0));
        temp += 1.0f / fps;
        if (temp >= 1) {
            frameCount++;
            temp = 0;
        }
        frameCount %= 3;
        //施加力
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnBirdAddForce();
        }
    }
    void OnBirdAddForce() {
        rigid.velocity=new Vector3(0,15,0);
    }
}
