namespace Leoka.Elementary.Platform.Models.MainPage.Output;

public class BestVariantOutput
{
    public int QuestionId { get; set; }

    public int MainBestOptionBlockId { get; set; }

    public string MainBestOptionQuestionText { get; set; }
    
    public string ButtonActionText { get; set; }

    public List<BestVariantItemsOutput> MainBestOptions { get; set; }
}