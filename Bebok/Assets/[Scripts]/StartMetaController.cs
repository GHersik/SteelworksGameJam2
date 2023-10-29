using UnityEngine;

public class StartMetaController : MonoBehaviour
{
    [SerializeField] GameOverCanvas gameOverCanvas;
    [SerializeField] BebokController bebokController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Becik")
        {
            gameOverCanvas.ShowPanel();
            bebokController.inpuEnabledt = false;
        }
    }
}
