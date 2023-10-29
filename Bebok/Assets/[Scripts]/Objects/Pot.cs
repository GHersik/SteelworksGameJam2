using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            particleSystem.Play();
            audioSource.Play();
        }  
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            //particleSystem.Play();
        }
    }
}
