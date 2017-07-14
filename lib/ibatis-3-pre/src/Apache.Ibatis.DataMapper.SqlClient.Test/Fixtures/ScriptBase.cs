using System.IO;
using Apache.Ibatis.Common.Data;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.Common.Utilities;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures
{
    public abstract class ScriptBase
    {
       protected string scriptDirectory = Path.Combine(Path.Combine(Path.Combine(Resources.ApplicationBase, ".."), ".."), "Scripts") + Path.DirectorySeparatorChar;


       /// <summary>
       /// Run a sql batch for the datasource.
       /// </summary>
       /// <param name="datasource">The datasource.</param>
       /// <param name="script">The sql batch</param>
       public void InitScript(IDataSource datasource, string script)
       {
           InitScript(datasource, script, true);
       }

       /// <summary>
       /// Run a sql batch for the datasource.
       /// </summary>
       /// <param name="datasource">The datasource.</param>
       /// <param name="script">The sql batch</param>
       /// <param name="doParse">parse out the statements in the sql script file.</param>
       private void InitScript(IDataSource datasource, string script, bool doParse)
       {
           ScriptRunner runner = new ScriptRunner();

           runner.RunScript(datasource, script, doParse);
       }
    }
}
