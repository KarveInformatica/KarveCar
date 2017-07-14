
using Apache.Ibatis.DataMapper.Configuration.Module;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Modules
{
    class AliasModule: Module
    {
        /// <summary>
        /// Override to add code configuration mapping to the <see cref="Apache.Ibatis.DataMapper.Configuration.IConfigurationEngine"/>.
        /// </summary>
        public override void Load()
        {
            RegisterAlias<SimpleSqlSource>();
            RegisterAlias<SqlSourceWithParameter>();
            RegisterAlias<SqlSourceWithInlineParameter>();
            RegisterAlias<NVelocityDynamicEngine>();
            RegisterAlias<IAccount>();
        }
    }
}
