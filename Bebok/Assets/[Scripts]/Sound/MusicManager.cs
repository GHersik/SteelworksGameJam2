using UnityEngine;
using DG.Tweening;

public class MusicManager : SingletonPersistent<MusicManager> {
    [Header("Settings")]
    [SerializeField] AudioSource firstChannel;
    [SerializeField] AudioSource secondChannel;
    [SerializeField] AudioSource thirdChannel;
    [SerializeField] float soundFadeTime = 1f;
    [SerializeField] float soundHardcoreFadeTime = 1f;
    [SerializeField] Ease hardCoreEase = Ease.Linear;

    [Header("Audio Clips")]
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioClip backgroundHardMusic;
    [SerializeField] AudioClip menuMusic;

    private void Start() {
        MainMenuTransition();
    }

    public void MainMenuTransition() {
        firstChannel.DOFade(1, soundFadeTime);
        secondChannel.DOFade(0,soundFadeTime);
    }

    public void NormalSceneTransition() {
        firstChannel.DOFade(0, soundFadeTime);
        secondChannel.DOFade(1, soundFadeTime);
    }

    public void HardCoreTransition() {
        thirdChannel.DOFade(1, soundHardcoreFadeTime).SetEase(hardCoreEase);
    }

    public void SoftCoreTransition() {
        thirdChannel.DOFade(0, soundHardcoreFadeTime).SetEase(hardCoreEase);
    }
}
