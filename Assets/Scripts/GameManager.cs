using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Transform firstBg;//当前状态最后一个Bg
    public static GameManager _instance;
    //单例模式
    void Awake() {
        _instance = this;
        firstBg = GameObject.Find("bg5").transform;
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
}
