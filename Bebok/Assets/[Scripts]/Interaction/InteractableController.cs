using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour {
    [SerializeField] InteractionTimer interactionTimer;

    IInteractable currentInteractable;
    float currentInteractionTime;

    private void Update() {
        GatherInputs();
        UpdateInteraction();
    }

    private void GatherInputs() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentInteractable != null)
                InteractionStart();
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            if (currentInteractable != null && currentInteractionTime != 0)
                HandleInteractionAction();
        }
    }

    private void UpdateInteraction() {
        if (currentInteractionTime != 0 && currentInteractionTime <= Time.time) {
            InteractionEnd();
        }
    }

    private void InteractionStart() {
        currentInteractable.InteractStart();
        currentInteractionTime = Time.time + currentInteractable.InteractionTime;

        interactionTimer.StartCountdown(currentInteractable.InteractionTime);
    }

    private void HandleInteractionAction() {
        if (currentInteractionTime <= Time.time) {
            InteractionEnd();
        }
        else {
            currentInteractable.InteractInterrupted();
            currentInteractionTime = 0;
            interactionTimer.HidePanel();
        }
    }

    private void InteractionEnd() {
        if (currentInteractable != null) {
            currentInteractable.InteractEnd();
            currentInteractionTime = 0;
            interactionTimer.HidePanel();
        }
    }

    private void ResetInteraction() {
        currentInteractionTime = 0;
        currentInteractable = null;

        interactionTimer.HidePanel();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Interactable")) {
            IInteractable interactable = collision.GetComponent<IInteractable>();
            if (interactable != null) {
                interactable.HighLight();
                currentInteractable = interactable;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Interactable")) {
            IInteractable interactable = collision.GetComponent<IInteractable>();
            if (interactable != null) {
                if (currentInteractionTime != 0)
                    interactable.InteractInterrupted();
                interactable.LowLight();
                ResetInteraction();
            }
        }
    }
}