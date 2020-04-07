public sealed class ScoreTextUpdater : TMPUpdater
{
    protected override void AdditionalOperationsInStart()
    {
        UpdateScoreText();
        GameCore.Instance.ScoreUpdated += UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        TextComponent.text = GameCore.Instance.CurrentScore.ToString();
    }
}
