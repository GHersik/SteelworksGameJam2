using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPanel : MonoBehaviour
{
    CanvasGroup panel;

    private void Start() {
        panel = GetComponent<CanvasGroup>();
    }

    public void ShowPanel() {
        panel.DOKill();
        panel.DOFade(1, .4f);
    }

    public void HidePanel() {
        panel.DOKill();
        panel.DOFade(0, .4f);
    }
}
