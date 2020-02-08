using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (currentState == GameState.END) {
            EndMenu();
        }
    }

    void EndMenu() {
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
        ResetValue();
        GameMenu._instance.gameObject.SetActive(false);//隐藏菜单栏
        score = 0;
        //重置score值
        GameObject.Find("ScorePanel").transform.GetComponent<Text>().text = "Your Score : " + score;
        currentState = GameState.MENU;//重置状态
    }

    void ResetValue() {
        GameObject.Find("bg1").transform.position=new Vector3(-1.84f,0,0);
        GameObject.Find("bg2").transform.position = new Vector3(8.16f, 0, 0);
        GameObject.Find("bg3").transform.position = new Vector3(18.16f, 0, 0);
        GameObject.Find("bg4").transform.position = new Vector3(28.16f, 0, 0);
        GameObject.Find("bg5").transform.position = new Vector3(38.16f, 0, 0);

        GameObject.Find("bird").transform.position = new Vector3(-9f, 2.6f, -1);
        GameObject.Find("bird").GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
        firstBg= GameObject.Find("bg5").transform;
    }

}
