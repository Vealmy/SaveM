using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScrpt : MonoBehaviour {
    public int min;
    public int max;
    public int fps=2;
    float timer;
    public int columns = 8;
    public int rows = 8;
    public int currentFrame = 0;

	// Use this for initialization
	void Start () {
        currentFrame = min;
        HandleMaterial();
        ResetTimer();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ResetTimer();
            currentFrame++;
            if (currentFrame > max)
            {
                currentFrame = min;
            }
            HandleMaterial();
        }
	}
    void ResetTimer() {
        timer = 1f / fps;
    }
    public void HandleMaterial() 
    {
        Vector2 framePosition = new Vector2();
        framePosition.x = currentFrame % columns;
        framePosition.y = currentFrame / columns;
        this.GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", new Vector2(1f / columns, 1f / rows));
    }

}
