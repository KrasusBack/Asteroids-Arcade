public class LivesTextUpdater : TMPUpdater
{
    protected override void AdditionalOperationsInStart()
    {
        UpdateLivesDisplay();
        GameCore.Instance.LivesCountUpdated += UpdateLivesDisplay;
    }

    private void UpdateLivesDisplay()
    {
        TextComponent.text = "Lives: " + GameCore.Instance.LivesCount.ToString();
    }
}
