namespace KeLi.MergedCell.App.Entities
{
    public struct SpanInfo
    {
        public SpanInfo(string headerText, int leftIndex, int rightIndex)
        {
            HeaderText = headerText;
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
        }

        public string HeaderText { get; }

        public int LeftIndex { get; }

        public int RightIndex { get; }
    }
}