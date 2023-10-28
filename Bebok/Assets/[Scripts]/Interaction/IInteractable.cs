public interface IInteractable {
    public float InteractionTime { get; set; }
    public void InteractStart();
    public void InteractEnd();
    public void InteractInterrupted();
    public void HighLight();
    public void LowLight();
}
