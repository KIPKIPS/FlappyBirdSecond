using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform bird;

    private float x;

    private bool isFollow;
    // Start is called before the first frame update
    void Start() {
        bird = GameObject.Find("bird").transform;
        x = transform.position.x;
        isFollow = true;
    }

    // Update is called once per frame
    void Update() {
        x += isFollow?Time.deltaTime * 5:0;
        transform.position=new Vector3(x,transform.position.y,transform.position.z);
    }
    
    public void StopMove() {
        Debug.Log("接收到消息");
        //Destroy(this);
        isFollow = false;
    }
}
