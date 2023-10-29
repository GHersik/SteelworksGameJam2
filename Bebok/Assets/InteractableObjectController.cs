using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] float interactionTime;
    [SerializeField] float malfunctionTime;
    [SerializeField] GameObject noiseMaker;
    [SerializeField] AudioSource malfunctionAudio;
    bool canBeUsed = true;
    bool malfunctioned = false;
    public float InteractionTime
    {
        get { return interactionTime; }
        set { interactionTime = value; }
    }

    public Vector3 InteractablePosition { get => this.transform.position; set => this.transform.position = value; }

    [SerializeField] ParticleSystem particles;
    [SerializeField] SpriteRenderer outlineSprite;
    [SerializeField] Color outlineColor;
    [SerializeField] Color malfunctionColor;
    [SerializeField] ParticleSystem malfunctionParticles;

    public void InteractInterrupted()
    {
        particles.Stop();
        noiseMaker.SetActive(false);
        canBeUsed = false;
        StartCoroutine(CanBeUsedAgain());

    }

    public void InteractStart()
    {
        if (canBeUsed)
        {
            particles.Play();
            noiseMaker.SetActive(true);
            StartCoroutine(CanBeUsedAgain());
        }
    }

    public void InteractEnd()
    {
        particles.Stop();
        noiseMaker.SetActive(false);
        canBeUsed = false;
        StartMalfunction();
        StartCoroutine(CanBeUsedAgain());
    }

    public void HighLight()
    {
        outlineColor.a = 1;
        outlineSprite.color = outlineColor;
    }

    public void LowLight()
    {
        outlineColor.a = 0;
        outlineSprite.color = outlineColor;
    }

    public bool CheckIfCanBeUsed()
    {
        return canBeUsed;
    }
    IEnumerator CanBeUsedAgain()
    {
        yield return new WaitForSecondsRealtime(InteractionTime * 2);
    }

    void StartMalfunction()
    {
        malfunctionParticles.Play();
        malfunctionAudio.Play();
        StartCoroutine(MalfunctionNoise());
        StartCoroutine(MalfanctionDuration());
        noiseMaker.SetActive(false);
    }

    void EndMalfunction()
    {
        malfunctionParticles.Stop();
        malfunctionAudio.Stop();
        malfunctioned = false;
    }

    IEnumerator MalfanctionDuration()
    {
        yield return new WaitForSecondsRealtime(malfunctionTime);
        EndMalfunction();
    }
    IEnumerator MalfunctionNoise()
    {
        for(int i = 0; i<malfunctionTime/.5f; i++) 
        {
            noiseMaker.SetActive(true);
            yield return new WaitForSecondsRealtime(.5f);
            noiseMaker.SetActive(false);
        }
    }
}
