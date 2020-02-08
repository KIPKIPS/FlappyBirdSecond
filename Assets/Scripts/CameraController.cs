using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform bird;
    //private bool isFollow;

    // Start is called before the first frame update
    void Start() {
        bird = GameObject.Find("bird").transform;
        //isFollow = true;
    }

    // Update is called once per frame
    void Update() {
        transform.position=new Vector3(bird.position.x+10.5f,0,transform.position.z);
    }
    
    public void StopMove() {
        Debug.Log("接收到消息");
        //Destroy(this);
        //isFollow = false;
    }
}
