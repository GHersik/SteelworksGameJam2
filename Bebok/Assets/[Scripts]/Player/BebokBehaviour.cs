using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebokBehaviour : MonoBehaviour {
    [Header("Settings")]
    [SerializeField, Range(0, 1)] float fadeAmount = 0.3f;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] SpriteRenderer sprite;

    Color spriteAlpha = Color.white;
    float currentFadeAmount;
    float amountToFadeTo;

    private void Start() {
        currentFadeAmount = 1;
        amountToFadeTo = currentFadeAmount;
    }

    private void Update() {
        currentFadeAmount = Mathf.Lerp(currentFadeAmount, amountToFadeTo, fadeTime * Time.deltaTime);
        AlterAlpha();
    }

    private void AlterAlpha() {
        spriteAlpha.a = currentFadeAmount;
        sprite.color = spriteAlpha;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("BlindSpot")) {
            amountToFadeTo = fadeAmount;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("BlindSpot")) {
            amountToFadeTo = 1;
        }
    }
}
