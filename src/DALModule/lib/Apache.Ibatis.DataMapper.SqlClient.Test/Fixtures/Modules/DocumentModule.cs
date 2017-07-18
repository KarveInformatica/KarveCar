using Apache.Ibatis.DataMapper.Configuration.Module;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Modules
{
    /// <summary>
    /// This module will register the resultMaps under the specified namespace Document
    /// </summary>
    public class DocumentModule : Module
    {
        public DocumentModule()
            : base("Document")
        { }

        public override void Load()
        {
            RegisterAlias<DocumentCollection>("DocumentCollection");

            RegisterResultMap<Document>("baseDocument")
                .MappingMember("Id").ToColumnName("Document_ID")
                .MappingMember("Title").ToColumnName("Document_Title");

            RegisterResultMap<Newspaper>("newspaper").Extends("baseDocument")
                .MappingMember("City").ToColumnName("Document_City");

            RegisterResultMap<Document>("document").Extends("baseDocument")
                .MappingMember("Test").ToColumnName("Document_Title")
                .WithDiscriminator<string>("Document_Type")
                .UsingResultMap("Document.book").ForValue("Book")
                .UsingResultMap("newspaper").ForValue("Newspaper");

            RegisterResultMap<Document>("document-custom-handler").Extends("baseDocument")
                .WithDiscriminator<string>("Document_Type")
                .WithTypeHandler<CustomInheritance>()
                .UsingResultMap("book").ForValue("Book")
                .UsingResultMap("newspaper").ForValue("Newspaper");

            RegisterResultMap<Book>("book").Extends("document")
                .MappingMember("PageNumber").ToColumnName("Document_PageNumber");
        }
    }
}
