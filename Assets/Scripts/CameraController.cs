using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform bird;

    private float x;
    // Start is called before the first frame update
    void Start() {
        bird = GameObject.Find("bird").transform;
        x = transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        x += Time.deltaTime * 5;
        transform.position=new Vector3(x,transform.position.y,transform.position.z);
    }
}
