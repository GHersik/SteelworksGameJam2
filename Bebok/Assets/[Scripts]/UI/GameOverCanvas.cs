using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] float fadeTime = .4f;
    [SerializeField] Button tryAgainButton;
    [SerializeField] Button backToMenuButton;
    [SerializeField] Button quitGameButton;

    bool isActive;
    CanvasGroup loadingPanel;

    private void Start() {
        loadingPanel = GetComponent<CanvasGroup>();

        tryAgainButton.onClick.AddListener(LoadLevelAgain_clicked);
        backToMenuButton.onClick.AddListener(MainMenuButton_clicked);
        quitGameButton.onClick.AddListener(QuitGameButton_clicked);
    }

    private void MainMenuButton_clicked() => ScenesLoader.Instance.LoadMainMenu();

    private void LoadLevelAgain_clicked() => ScenesLoader.Instance.LoadCurrentLevel();

    private void QuitGameButton_clicked() => ScenesLoader.Instance.QuitGame();

    public void ShowPanel() {
        loadingPanel.DOKill();
        loadingPanel.DOFade(1, fadeTime).SetUpdate(true).OnComplete(SetInteractable);
    }

    private void SetInteractable() {
        loadingPanel.interactable = true;
        loadingPanel.blocksRaycasts = true;
    }

    public void HidePanel() {
        loadingPanel.DOKill();
        loadingPanel.DOFade(0, fadeTime).SetUpdate(true).OnComplete(SetNotInteractable); ;
    }

    private void SetNotInteractable() {
        loadingPanel.interactable = false;
        loadingPanel.blocksRaycasts = false;
    }

    private void OnDisable() {
        DOTween.Kill(loadingPanel);
        Time.timeScale = 1;
        HidePanel();
    }
}
