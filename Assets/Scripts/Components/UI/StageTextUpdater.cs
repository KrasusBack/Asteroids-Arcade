public sealed class StageTextUpdater : TMPUpdater
{
    protected override void AdditionalOperationsInStart()
    {
        UpdateStageNumberText();
        GameCore.Instance.StageNumberUpdated += UpdateStageNumberText;
    }

    private void UpdateStageNumberText()
    {
        TextComponent.text = "Stage: " + GameCore.Instance.CurrentStage.ToString();
    }
}
