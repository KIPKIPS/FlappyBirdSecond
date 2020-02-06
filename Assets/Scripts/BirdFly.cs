using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {
    public Material mat;
    public int frameCount;

    public int fps;
    private  float temp;
    // Start is called before the first frame update
    void Start() {
        mat = GetComponent<Renderer>().material;
        frameCount = 0;
        temp = 0;
    }

    // Update is called once per frame
    void Update() {
        mat.SetTextureOffset(1,new Vector2(frameCount*1/3.0f,0));
        
        temp +=1.0f/fps;
        if (temp>=1) {
            frameCount++;
            temp = 0;
        }
        
        frameCount %= 3;
    }
}
