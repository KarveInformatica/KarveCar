using Apache.Ibatis.DataMapper.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apache.Ibatis.DataMapper
{
    public class ScopedSession : ISessionScope
    {
        private ISession _session;
        public ScopedSession(ISession session)
        {
            _session = session;
        }
        public ISession Session { get
            {
                return _session;
            }
        }

        public void Dispose()
        {
            _session.Close();
        }
    }
}
