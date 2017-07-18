using Apache.Ibatis.DataMapper.Configuration.Module;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Modules
{
    /// <summary>
    /// This module will register the resultMaps under the convention namespace Account
    /// </summary>
    public class EventModule : Module
    {
        public EventModule()
            : base("Account")
        {}

        public override void Load()
        {
            RegisterAlias<Account>();
            RegisterAlias<Document>();

            RegisterResultMap<Account>("account-result")
                .MappingMember("id").ToColumnName("Account_ID")
                .MappingMember("FirstName").ToColumnName("Account_FirstName")
                .MappingMember("LastName").ToColumnName("Account_LastName")
                .MappingMember("EmailAddress").ToColumnName("Account_Email").UsingNullValue("no_email@provided.com");

            RegisterResultMap<Account>("account-result-constructor")
                .UsingConstructor
                    .MappingArgument("identifiant").ToColumnName("Account_ID")
                    .MappingArgument("firstName").ToColumnName("Account_FirstName")
                    .MappingArgument("lastName").ToColumnName("Account_LastName")
                .MappingMember("EmailAddress").ToColumnName("Account_Email").UsingNullValue("no_email@provided.com");


            RegisterResultMap<Account>("account-result-with-document")
                .MappingMember("id").ToColumnName("Account_ID")
                .MappingMember("FirstName").ToColumnName("Account_FirstName")
                .MappingMember("LastName").ToColumnName("Account_LastName")
                .MappingMember("EmailAddress").ToColumnName("Account_Email").UsingNullValue("no_email@provided.com")
                .MappingMember("Document").ToColumnName("Id=Account_ID").UsingSelect("SelectDocument");

        }
    }
}
