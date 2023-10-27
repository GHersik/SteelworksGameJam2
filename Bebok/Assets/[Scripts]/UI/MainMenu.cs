using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [Header("Settigs")]
    [SerializeField] Button newGameButton;
    [SerializeField] Button quitGameButton;

    private void Start() {
        newGameButton.onClick.AddListener(MainMenuButton_clicked);
        quitGameButton.onClick.AddListener(QuitGameButton_clicked);
    }

    private void MainMenuButton_clicked() => ScenesLoader.Instance.LoadNewGame();

    private void QuitGameButton_clicked() => ScenesLoader.Instance.QuitGame();
}
