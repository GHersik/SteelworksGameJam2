using UnityEngine;
using DG.Tweening;

public class MusicManager : SingletonPersistent<MusicManager> {
    [Header("Settings")]
    [SerializeField] AudioSource firstChannel;
    [SerializeField] AudioSource secondChannel;
    [SerializeField] AudioSource thirdChannel;
    [SerializeField] float soundFadeTime = 1f;
   [SerializeField] float soundHardcoreFadeTime = 1f;
   [SerializeField] Ease fadeCurve;

    [Header("Audio Clips")]
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioClip backgroundMusicHard;
    [SerializeField] AudioClip menuMusic;

    private void Start() {
        MainMenuTransition();
    }

    public void MainMenuTransition() {
        firstChannel.DOFade(1, soundFadeTime);
        secondChannel.DOFade(0,soundFadeTime);
        thirdChannel.DOFade(0,soundFadeTime);
    }

    public void NormalSceneTransition() {
        firstChannel.DOFade(0, soundFadeTime);
        secondChannel.DOFade(1, soundFadeTime);
        thirdChannel.DOFade(0, soundHardcoreFadeTime);
    }

        public void HardcoreTransition() {
        thirdChannel.DOFade(1, soundHardcoreFadeTime).SetEase(fadeCurve);
    }
        public void SoftcoreTransition() {
        thirdChannel.DOFade(0, soundHardcoreFadeTime).SetEase(fadeCurve);
    }
}
