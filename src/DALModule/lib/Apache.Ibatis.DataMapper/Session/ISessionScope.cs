namespace Apache.Ibatis.DataMapper.Session
{
    public interface ISessionScope
    {
        ISession Session
        {  get;}
        void Dispose();
    }
}