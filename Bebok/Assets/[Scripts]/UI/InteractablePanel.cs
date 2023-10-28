using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractablePanel : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] float fadeTime;
    [SerializeField] float delayTime;

    CanvasGroup panel;

    private void ShowPanel() {
        panel.DOKill();
        panel.DOFade(1, fadeTime).SetDelay(delayTime);
    }

    private void HidePanel() {
        panel.DOKill();
        panel.DOFade(0, fadeTime);
    }
}
