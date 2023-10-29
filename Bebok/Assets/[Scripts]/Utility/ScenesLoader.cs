using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ScenesLoader : Singleton<ScenesLoader> {
    public enum Scene {
        MainMenu,
        Level01,
        Level02,
        Level03,
    }

    [SerializeField] CanvasGroup loadingPanel;
    [SerializeField] float fadeTime;

    public void QuitGame() => Application.Quit();

    public void LoadMainMenu() => StartCoroutine(LoadScene(Scene.MainMenu));

    public void LoadNewGame() => StartCoroutine(LoadScene(Scene.Level01));

    public void LoadLevel2() => StartCoroutine(LoadScene(Scene.Level02));

    public void LoadLevel3() => StartCoroutine(LoadScene(Scene.Level03));

    private IEnumerator LoadScene(Scene scene) {
        if (scene == Scene.MainMenu)
            MusicManager.Instance.MainMenuTransition();
        else
            MusicManager.Instance.NormalSceneTransition();

        Time.timeScale = 1;
        ShowPanel();

        yield return new WaitForSeconds(1f);
        var asyncLoadLevel = SceneManager.LoadSceneAsync((int)scene);

        yield return new WaitForSeconds(1f);
        yield return asyncLoadLevel;

        HidePanel();
        yield return new WaitForSeconds(fadeTime);
    }

    private void ShowPanel() {
        loadingPanel.DOKill();
        loadingPanel.DOFade(1, fadeTime).SetUpdate(true);
    }

    private void HidePanel() {
        loadingPanel.DOKill();
        loadingPanel.DOFade(0, fadeTime).SetUpdate(true);
    }

    private void OnDisable() {
        DOTween.Kill(loadingPanel);
    }
}
