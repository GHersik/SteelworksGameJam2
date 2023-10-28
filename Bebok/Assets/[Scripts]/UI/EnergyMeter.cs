using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] Image meterImage;
    [SerializeField] float fadeTime;
    [SerializeField] BebokController player;

    CanvasGroup panel;
    private float timeAmountCountdown;

    private void Start() {
        panel = GetComponent<CanvasGroup>();
    }

    private void Update() {
        UpdateMeter();
    }

    private void UpdateMeter() {
        float fillAmount = player.CurrentEnergy / player.MaxEnergy;
        meterImage.fillAmount = fillAmount;

        if (fillAmount == 1) {
            HidePanel();
        }
        else {
            ShowPanel();
        }
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
