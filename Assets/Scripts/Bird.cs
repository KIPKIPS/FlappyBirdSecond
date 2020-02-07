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
}
