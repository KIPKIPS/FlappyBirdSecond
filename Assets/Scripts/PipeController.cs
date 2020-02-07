using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        RandomPipePosition();
    }

    // Update is called once per frame
    void Update() {
        
    }
    //生成管道随机位置
    public void RandomPipePosition() {
        float posY = UnityEngine.Random.Range(-0.4f, -0.1f);//生成随机数
        //使用localPosition 改变本地坐标 而非世界坐标
        transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);//修改Y坐标
    }
}
