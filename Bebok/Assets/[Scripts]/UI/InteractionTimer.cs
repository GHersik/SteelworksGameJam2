using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InteractionTimer : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] Image timerImage;
    [SerializeField] float fadeTime;

    CanvasGroup panel;
    private float timeAmountCountdown;
    private float fillAmountNeeded;
    private float currentFillAmount;

    private void Start() {
        panel = GetComponent<CanvasGroup>();
    }

    public void PositionPanel(Vector3 positionToPlace) {
        this.transform.position = positionToPlace;
    }

    public void StartCountdown(float time) {
        timeAmountCountdown = time;
        fillAmountNeeded = Time.time + timeAmountCountdown;
        timerImage.fillAmount = 1;
        ShowPanel();
    }

    public void StopCountDown() {
        HidePanel();
    }

    private void Update() {
        UpdateTimer();
    }

    private void UpdateTimer() {
        currentFillAmount = Time.time;
        timerImage.fillAmount = (fillAmountNeeded - currentFillAmount) / timeAmountCountdown;
    }

    public void ShowPanel() {
        panel.DOKill();
        panel.DOFade(1, fadeTime);
    }

    public void HidePanel() {
        panel.DOKill();
        panel.DOFade(0, fadeTime);
    }
}
