using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class GameLost  : Singleton<GameLost>{
    [Header("Settings")]
    [SerializeField] float fadeTime = .4f;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitGameButton;

    bool isActive;
    CanvasGroup loadingPanel;


    private void Start() {
        loadingPanel = GetComponent<CanvasGroup>();

        mainMenuButton.onClick.AddListener(MainMenuButton_clicked);
        quitGameButton.onClick.AddListener(QuitGameButton_clicked);
    }



    private void MainMenuButton_clicked() => ScenesLoader.Instance.LoadNewGame();

    private void QuitGameButton_clicked() => ScenesLoader.Instance.QuitGame();

    public void ShowPanel() {
        loadingPanel.DOKill();
        loadingPanel.DOFade(1, fadeTime).SetUpdate(true).OnComplete(SetInteractable);
        Time.timeScale = 0;
    }

    private void SetInteractable() {
        loadingPanel.interactable = true;
        loadingPanel.blocksRaycasts = true;
    }

    private void HidePanel() {
        Time.timeScale = 1;
        loadingPanel.DOKill();
        loadingPanel.DOFade(0, fadeTime).SetUpdate(true).OnComplete(SetNotInteractable); ;
    }

    private void SetNotInteractable() {
        loadingPanel.interactable = false;
        loadingPanel.blocksRaycasts = false;
    }

    private void OnDisable() {
        DOTween.Kill(loadingPanel);
    }
    
}
