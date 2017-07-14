
using System;
using System.IO;
using System.Xml;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


// http://www.codeplex.com/Json

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Domain
{
	public class JsonInterpreter : AbstractInterpreter 
	{
	    private readonly XmlConfigurationInterpreter xmlInterpreter = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonInterpreter"/> class.
        /// </summary>
        /// <param name="source">The <see cref="IResource"/>.</param>
        public JsonInterpreter(IResource source) : base(source)
        {
            string xmlContents = string.Empty;
            using(source)
            {
                JsonReader reader = new JsonTextReader(new StreamReader(source.Stream));
                reader.Read();

                XmlNodeConverter toXml = new XmlNodeConverter();
                XmlDocument xmlDoc = (XmlDocument)toXml.ReadJson(reader, typeof(XmlDocument));
                xmlContents = xmlDoc.OuterXml;
                reader.Close();                
            }

            IResource resource = new StaticContentResource(xmlContents);

            xmlInterpreter = new XmlConfigurationInterpreter(resource);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonInterpreter"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public JsonInterpreter(string fileName)
            : base(ResourceLoaderRegistry.GetResource(fileName))
        {}


	    //private XmlInterpreter _xmlInterpreter = new XmlInterpreter();



        ///// <summary>
        ///// Gets or sets the kernel.
        ///// </summary>
        ///// <value>The kernel.</value>
        //public IKernel Kernel
        //{
        //    get { return _xmlInterpreter.Kernel ; }
        //    set { _xmlInterpreter.Kernel = value; }
        //}

        //public override void ProcessResource(IResource source, IConfigurationStore store)
        //{

        //    XmlNodeConverter toXml = new XmlNodeConverter();
        //    JsonReader reader = new JsonReader(source.GetStreamReader());
        //    reader.Read();
        //    XmlDocument xmlDoc = (XmlDocument)toXml.ReadJson(reader, typeof(XmlDocument));
        //    StaticContentResource xmlSource = new StaticContentResource(xmlDoc.OuterXml);

        //    _xmlInterpreter.ProcessResource(xmlSource, store);
        //}

        public override void ProcessResource(IConfigurationStore store)
        {
            xmlInterpreter.ProcessResource(store);
        }
    }
}
