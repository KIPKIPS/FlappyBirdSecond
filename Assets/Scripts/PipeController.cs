using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            float r= UnityEngine.Random.Range(-0.4f, -0.1f);//生成随机数
            transform.position = new Vector3(transform.position.x, 15*r,transform.position.z);//修改Y坐标
        }
    }
}
