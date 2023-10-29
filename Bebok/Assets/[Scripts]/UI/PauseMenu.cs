using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
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

    private void Update() {
        GatherInputs();
    }

    private void MainMenuButton_clicked() {
        Time.timeScale = 1;
        ScenesLoader.Instance.LoadMainMenu();
    }

    private void QuitGameButton_clicked() {
        Time.timeScale = 1;
        ScenesLoader.Instance.QuitGame();
    }

    void GatherInputs() {
        if (GameManager.Instance.gameState == GameManager.GameStates.Finished) 
            return;
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isActive) {
                isActive = false;
                HidePanel();
            }
            else {
                isActive = true;
                ShowPanel();
            }
        }
    }

    private void ShowPanel() {
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
