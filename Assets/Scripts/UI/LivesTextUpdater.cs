public class LivesTextUpdater : TMPUpdater
{
    protected override void AdditionalOperationsInStart()
    {
        UpdateLivesText();
        GameCore.Instance.LivesCountUpdated += UpdateLivesText;
    }

    private void UpdateLivesText()
    {
        TextComponent.text = "Lives: " + GameCore.Instance.LivesCount.ToString();
    }
}
