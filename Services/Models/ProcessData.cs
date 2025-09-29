using Services.Enums;

namespace Services
{
    public class ProcessData
    {
        public string Text { get; set; }
        public DataLabel Label { get; set; } = DataLabel.None;

        public ProcessData(string text)
        {
            Text = text;
        }

        public ProcessData(string text, DataLabel label = DataLabel.None) : this(text)
        {
            Label = label;
        }
    }
}
