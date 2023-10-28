using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebokBehaviour : MonoBehaviour {
    [Header("Settings")]
    [SerializeField, Range(0, 1)] float fadeAmount = 0.3f;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject enemyChaser;
    [SerializeField] GameObject becik;

    Color spriteAlpha = Color.white;
    float currentFadeAmount;
    float amountToFadeTo;

    bool becikCanBePickedUp = false;

    private void Start() {
        currentFadeAmount = 1;
        amountToFadeTo = currentFadeAmount;
    }

    private void Update() {
        currentFadeAmount = Mathf.Lerp(currentFadeAmount, amountToFadeTo, fadeTime * Time.deltaTime);
        AlterAlpha();
        if (Input.GetKey(KeyCode.E) && becikCanBePickedUp)
        {
            var becikController = becik.GetComponent<BecikController>();
            becikController.TransportChild(this.transform);
        }
    }

    private void AlterAlpha() {
        spriteAlpha.a = currentFadeAmount;
        sprite.color = spriteAlpha;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("BlindSpot")) {
            amountToFadeTo = fadeAmount;
            enemyChaser.SetActive(false);
        }
        if (collision.transform.gameObject.layer == 6)//6layer to enenmy
        {
            Destroy(this.gameObject);
        }

        if (collision.transform.gameObject.name == "Becik")
        {
            becikCanBePickedUp = true;
            becik = collision.transform.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("BlindSpot")) {
            amountToFadeTo = 1;
            enemyChaser.SetActive(true);
        }
        if (collision.transform.gameObject.name == "Becik")
        {

            becikCanBePickedUp = false;
            becik = null;
        }
    }
}
