using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    public Transform currentBg;

    public PipeController pipe1;
    public PipeController pipe2;
    // Start is called before the first frame update
    void Start() {
        currentBg = this.transform.parent;
        //获取子游戏对象的组件
        //GetChild(int index);index为子物体的索引值(从零开始)
        pipe1 = currentBg.GetChild(1).transform.GetComponent<PipeController>();
        pipe2 = currentBg.GetChild(2).transform.GetComponent<PipeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            //Debug.Log("OnTrigger");
            Transform firstBg = GameManager._instance.firstBg;
            //将当前Bg沿x坐标轴移动十个单位
            currentBg.position=new Vector3(firstBg.position.x+10, currentBg.position.y, currentBg.position.z);
            GameManager._instance.firstBg = currentBg;

            //重新生成管道的位置
            pipe1.RandomPipePosition();
            pipe2.RandomPipePosition();
        }
    }
}
