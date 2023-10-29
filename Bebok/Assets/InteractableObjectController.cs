using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] float interactionTime;
    [SerializeField] GameObject noiseMaker;
    bool canBeUsed = true;
    public float InteractionTime
    {
        get { return interactionTime; }
        set { interactionTime = value; }
    }

    public Vector3 InteractablePosition { get => this.transform.position; set => this.transform.position = value; }

    [SerializeField] ParticleSystem particles;
    [SerializeField] SpriteRenderer outlineSprite;
    [SerializeField] Color outlineColor;

    public void InteractInterrupted()
    {
        // Debug.Log("Interaction with the object interrupted!");
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
        }// Debug.Log("I have came into interaction with the player!");
    }

    public void InteractEnd()
    {
        //Debug.Log("Interaction with the object is concluded!");
        particles.Stop();
        noiseMaker.SetActive(false);
        canBeUsed = false;
        StartCoroutine(CanBeUsedAgain());
    }

    public void HighLight()
    {
        //Debug.Log("I am being highlighted!");
        outlineColor.a = 1;
        outlineSprite.color = outlineColor;
    }

    public void LowLight()
    {
        //Debug.Log("I am not highlighted anymore!");
        outlineColor.a = 0;
        outlineSprite.color = outlineColor;
    }

    IEnumerator CanBeUsedAgain()
    {
        yield return new WaitForSecondsRealtime(InteractionTime * 2);
    }
}
