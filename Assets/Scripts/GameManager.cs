using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Transform firstBg;//当前状态最后一个Bg
    public static GameManager _instance;
    internal int score;
    private int highestScore;

    public IEnumerator ie;
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
        highestScore = 0;
        ie = EndMenu();
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
        if (_instance.currentState == GameState.END) {
            StartCoroutine(ie);
        }


    }

    IEnumerator EndMenu() {
        yield return new WaitForSeconds(2);
        GameMenu._instance.gameObject.SetActive(true);
        GameObject.Find("CurrentScore").GetComponent<Text>().text = "" + _instance.score;
        if (_instance.score > highestScore) {
            highestScore = _instance.score;
            GameObject.Find("HighestScore").GetComponent<Text>().text = "" + highestScore;
        }
    }
    public void SetState(GameState state) {
        currentState = state;
    }
    public void OnRestartButton() {
        GameMenu._instance.gameObject.SetActive(false);
    }


}
