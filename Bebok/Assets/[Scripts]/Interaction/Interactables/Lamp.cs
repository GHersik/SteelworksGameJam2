using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Lamp : MonoBehaviour, IInteractable {
    [Header("Settings")]
    [SerializeField] float interactionTime;
    public float InteractionTime {
        get { return interactionTime; }
        set { interactionTime = value; }
    }

    [SerializeField] ParticleSystem particles;
    [SerializeField] SpriteRenderer outlineSprite;
    [SerializeField] Color outlineColor;

    public void InteractInterrupted() {
        Debug.Log("Interaction with the object interrupted!");
        particles.Stop();
    }

    public void InteractStart() {
        particles.Play();
        Debug.Log("I have came into interaction with the player!");
    }

    public void InteractEnd() {
        Debug.Log("Interaction with the object is concluded!");
        particles.Stop();
    }

    public void HighLight() {
        Debug.Log("I am being highlighted!");
        outlineColor.a = 1;
        outlineSprite.color = outlineColor;
    }

    public void LowLight() {
        Debug.Log("I am not highlighted anymore!");
        outlineColor.a = 0;
        outlineSprite.color = outlineColor;
    }
}
