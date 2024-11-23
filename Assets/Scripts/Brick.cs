using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour {
    public UnityEvent<int> onDestroyed;

    public MainManager MainManager;

    public int PointValue;

    void Start() {
        MainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        if (PointValue < 3) {
            block.SetColor("_BaseColor", Color.green);
        } else if (PointValue >= 3 && PointValue <= 5) {
            block.SetColor("_BaseColor", Color.yellow);
        } else if (PointValue >= 6 && PointValue <= 9) {
            block.SetColor("_BaseColor", Color.blue);
        } else {
            block.SetColor("_BaseColor", Color.red);
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other) {
        onDestroyed.Invoke(PointValue);

        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
