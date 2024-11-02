using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour{
    [Header("Dependencies")]
    public Sprite[] Sprites;
    public SpriteRenderer SpriteRenderer;
    public int animationSpeed = 5;
    float i = 0;
    void OnTriggerEnter2D(Collider2D col) {
        if (col.attachedRigidbody && col.attachedRigidbody.TryGetComponent(out PlayerCharacter player)) {
            print("Teleport!");
        }
    }

    void Update() {
        SpriteRenderer.sprite = Sprites[(int) Math.Floor(i) % 6 + 2];
        i += Time.deltaTime * animationSpeed;
    }
}
