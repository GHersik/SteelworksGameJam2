using System.Collections;
using UnityEngine;

public class BecikController : MonoBehaviour
{
    public float InteractionTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Vector3 InteractablePosition { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    [SerializeField] float speedModifierForBebok = .9f;
    [SerializeField]
    Transform carrier;
    [SerializeField]
    AudioSource crySource;
    [SerializeField]
    GameObject noiseMaker;

    bool becikIsNotInHisPlace = false;
    private void Update()
    {
        if (carrier != null)
            this.transform.position = carrier.position;
        if (becikIsNotInHisPlace)
        {
            StartCoroutine(AlertOthers());
        }
    }
    public void HighLight()
    {
        throw new System.NotImplementedException();
    }

    public void InteractEnd()
    {
        throw new System.NotImplementedException();
    }

    public void InteractInterrupted()
    {
        throw new System.NotImplementedException();
    }

    public void InteractStart()
    {
        throw new System.NotImplementedException();
    }

    public void LowLight()
    {
        throw new System.NotImplementedException();
    }

    public void TransportChild(Transform _carrier, BebokController bebokController)
    {
        bebokController.speedModifier = speedModifierForBebok;
        becikIsNotInHisPlace = true;
        carrier = _carrier;
        crySource.Play();
    }

    public void BecikPickedByFamily(Transform _carrier)
    {
        becikIsNotInHisPlace = false;
        carrier = _carrier;
    }

    public void PlaceBecikInCraddle(Transform craddlePlace)
    {
        this.transform.position = craddlePlace.position;
        becikIsNotInHisPlace = false;
        carrier = null;
        crySource.Play();
    }

    public void PutBecikDown(BebokController bebokController)
    {
        bebokController.speedModifier = 1f;
        carrier = null;
    }
    IEnumerator AlertOthers()
    {
        noiseMaker.SetActive(true);
        yield return new WaitForSeconds(.5f);
        noiseMaker.SetActive(false);
    }
}
