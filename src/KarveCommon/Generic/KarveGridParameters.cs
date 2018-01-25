using System;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  KarveGridParameters,. This are all the parameters.
    /// </summary>
    public class KarveGridParameters
    {
        // Grid identifier
        private long _gridIdentifier;
        // GridName
        private string _gridName;
        // XmlBase64
        private string _xml;
        // PreviousXmlBase64
        private string _previousXml;

        public KarveGridParameters()
        {
            _gridIdentifier = long.MinValue;
            _gridName = string.Empty;
            _xml = null;
            _previousXml = null;
        }
        /// <summary>
        /// GridParameters.
        /// </summary>
        /// <param name="identifer">Long identifier</param>
        /// <param name="name">Name identifier</param>
        /// <param name="arrayData">Data array</param>
        public KarveGridParameters(long identifer, string name, string arrayData)
        {
            GridIdentifier = identifer;
            GridName = name;
            Xml= arrayData;
            PreviousXml = arrayData;
          
        }

        public long GridIdentifier
        {
            get { return _gridIdentifier; }
            set { _gridIdentifier = value; }
        }

        public string GridName
        {
            get { return _gridName; }
            set { _gridName = value; }
        }

        public string Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        public string PreviousXml
        {
            get { return _previousXml; }
            set { _previousXml = value; }
        }
       

    }


}