using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Transform firstBg;//当前状态最后一个Bg
    public static GameManager _instance;
    internal int score;

    public enum GameState {
        MENU,
        RUNNING,
        END
    }
    public GameState currentState;//当前游戏状态
    //单例模式
    void Awake() {
        currentState = GameState.MENU;
        _instance = this;
        firstBg = GameObject.Find("bg5").transform;
        score = 0;
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKey&&currentState!=GameState.END) {
            if (currentState == GameState.MENU) {
                GetComponent<AudioSource>().Play();
            }
            currentState = GameState.RUNNING;
        }
        
    }

    public void SetState(GameState state) {
        currentState = state;
    }
}
