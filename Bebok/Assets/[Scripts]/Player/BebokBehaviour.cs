using UnityEngine;

public class BebokBehaviour : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Range(0, 1)] float fadeAmount = 0.3f;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject enemyChaser;
    [SerializeField] GameObject becik;
    [SerializeField] BebokController bebokController;

    Color spriteAlpha = Color.white;
    float currentFadeAmount;
    float amountToFadeTo;

    bool becikCanBePickedUp = false;
    bool becikPickedUp = false;

    private void Start()
    {
        currentFadeAmount = 1;
        amountToFadeTo = currentFadeAmount;
    }

    private void Update()
    {
        currentFadeAmount = Mathf.Lerp(currentFadeAmount, amountToFadeTo, fadeTime * Time.deltaTime);
        AlterAlpha();
        if (Input.GetKeyDown(KeyCode.Space) && becikCanBePickedUp)
        {
            var becikController = becik.GetComponent<BecikController>();
            becikController.TransportChild(this.transform, bebokController);
            becikCanBePickedUp = false;
            becikPickedUp = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && becikPickedUp)
        {
            var becikController = becik.GetComponent<BecikController>();
            becikController.PutBecikDown(bebokController);
            becikCanBePickedUp = true;
            becikPickedUp = false;
        }
    }

    private void AlterAlpha()
    {
        spriteAlpha.a = currentFadeAmount;
        sprite.color = spriteAlpha;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlindSpot"))
        {
            amountToFadeTo = fadeAmount;
            enemyChaser.SetActive(false);
        }
        if (collision.transform.gameObject.layer == 6)//6layer to enenmy
        {
            //Destroy(this.gameObject);
            GameManager.Instance.LoseGame();
        }

        if (collision.transform.gameObject.name == "Becik")
        {
            becikCanBePickedUp = true;
            becik = collision.transform.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BlindSpot"))
        {
            amountToFadeTo = 1;
            enemyChaser.SetActive(true);
        }
        if (collision.transform.gameObject.name == "Becik")
        {

            becikCanBePickedUp = false;
            becik = null;
        }
    }
}