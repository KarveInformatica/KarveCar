namespace KarveCommon.Generic
{
    public interface ISqlCommand
    {
        string CommandStatemement { set; get; }
        void ExecuteNoQuery();
	void ExecuteQuery();
    }
}