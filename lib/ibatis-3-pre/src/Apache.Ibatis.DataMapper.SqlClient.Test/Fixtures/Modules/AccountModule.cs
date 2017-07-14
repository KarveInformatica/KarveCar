using Apache.Ibatis.DataMapper.Configuration.Module;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Modules
{
    /// <summary>
    /// This module will register the resultMaps under the convention namespace Account
    /// </summary>
    public class AccountModule : Module
    {

        public override void Load()
        {
            RegisterTypeHandler<bool, OuiNonBoolTypeHandlerCallback>("Varchar");

            RegisterResultMap<Account>("account-result-nullable-email")
                .MappingMember("Id").ToColumnName("Account_ID")
                .MappingMember("FirstName").ToColumnName("Account_FirstName")
                .MappingMember("LastName").ToColumnName("Account_LastName")
                .MappingMember("EmailAddress").ToColumnName("Account_Email");

            RegisterParameterMap<Account>("insert-params")
                .MappingMember("Id").ToColumn("Account_ID")
                .MappingMember("FirstName").ToColumn("Account_FirstName")
                .MappingMember("LastName").ToColumn("Account_LastName")
                .MappingMember("EmailAddress").ToColumn("Account_Email").UsingNullValue("no_email@provided.com")
                .MappingMember("BannerOption").ToColumn("Account_Banner_Option").UsingDbType("Varchar").UsingType("bool")
                .MappingMember("CartOption").ToColumn("Account_Cart_Option").WithTypeHandler<HundredsTypeHandlerCallback>();
   
            RegisterResultMap<Account>("account-result-constructor")
                .UsingConstructor
                    .MappingArgument("identifiant").ToColumnName("Account_ID")
                    .MappingArgument("firstName").ToColumnName("Account_FirstName")
                    .MappingArgument("lastName").ToColumnName("Account_LastName")
                .MappingMember("EmailAddress").ToColumnName("Account_Email").UsingNullValue("no_email@provided.com")
                .MappingMember("BannerOption").ToColumnName("Account_Banner_Option").UsingDbType("Varchar").UsingType("bool")
                .MappingMember("CartOption").ToColumnName("Account_Cart_Option").WithTypeHandler<HundredsTypeHandlerCallback>();

            RegisterResultMap<Account>("account-result-joined-document")
                .MappingMember("id").ToColumnName("Account_ID")
                .MappingMember("FirstName").ToColumnName("Account_FirstName")
                .MappingMember("LastName").ToColumnName("Account_LastName")
                .MappingMember("EmailAddress").ToColumnName("Account_Email").UsingNullValue("no_email@provided.com")
                .MappingMember("BannerOption").ToColumnName("Account_Banner_Option").UsingDbType("Varchar").UsingType("bool")
                .MappingMember("CartOption").ToColumnName("Account_Cart_Option").WithTypeHandler<HundredsTypeHandlerCallback>()
                .MappingMember("Document").UsingResultMap("Document.document");

        }
    }
}
