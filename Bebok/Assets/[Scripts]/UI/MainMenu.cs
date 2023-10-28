using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [Header("Settigs")]
    [SerializeField] Button newGameButton;
    [SerializeField] Button quitGameButton;

    CanvasGroup panel;  

    private void Start() {
        newGameButton.onClick.AddListener(MainMenuButton_clicked);
        quitGameButton.onClick.AddListener(QuitGameButton_clicked);

        panel = GetComponent<CanvasGroup>();
    }

    private void MainMenuButton_clicked() => ScenesLoader.Instance.LoadNewGame();

    private void QuitGameButton_clicked() => ScenesLoader.Instance.QuitGame();

    public void ShowPanel() {
        panel.DOKill();
        panel.DOFade(1, .4f);
    }

    public void HidePanel() {
        panel.DOKill();
        panel.DOFade(0, .4f);
    }
}
