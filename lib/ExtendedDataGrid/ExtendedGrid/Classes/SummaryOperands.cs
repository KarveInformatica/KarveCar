namespace ExtendedGrid.Classes
{
    public interface ISummaryOperands
    {
        string Operation { get; }
    }

    public class SumSummaryOperands:ISummaryOperands
    {
        public string Operation
        {
            get { return "Sum"; }
        }
    }
    public class CountSummaryOperands : ISummaryOperands
    {
        public string Operation
        {
            get { return "Count"; }
        }
    }
    public class AverageSummaryOperands : ISummaryOperands
    {
        public string Operation
        {
            get { return "Average"; }
        }
    }
    public class MaximumSummaryOperands : ISummaryOperands
    {
        public string Operation
        {
            get { return "Max"; }
        }
    }
    public class MinimumSummaryOperands : ISummaryOperands
    {
        public string Operation
        {
            get { return "Min"; }
        }
    }
    public class LargestSummaryOperands : ISummaryOperands
    {
        public string Operation
        {
            get { return "Lasrgest"; }
        }

    }
    public class SmallestSummaryOperands : ISummaryOperands
    {
        public string Operation
        {
            get { return "Smallest"; }
        }
    }
}
