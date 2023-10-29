using UnityEngine;
using DG.Tweening;

public class MusicManager : SingletonPersistent<MusicManager> {
    [Header("Settings")]
    [SerializeField] AudioSource firstChannel;
    [SerializeField] AudioSource secondChannel;
    [SerializeField] float soundFadeTime = 1f;

    [Header("Audio Clips")]
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioClip menuMusic;

    private void Start() {
        MainMenuTransition();
    }

    public void MainMenuTransition() {
        firstChannel.DOFade(0, soundFadeTime);
        secondChannel.DOFade(1,soundFadeTime);
    }

    public void NormalSceneTransition() {
        firstChannel.DOFade(1, soundFadeTime);
        secondChannel.DOFade(0, soundFadeTime);
    }
}
