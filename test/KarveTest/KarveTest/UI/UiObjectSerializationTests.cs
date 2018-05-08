using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls.UIObjects;
using NUnit.Framework;
using ExtendedXmlSerialization;

namespace KarveTest.UI
{
    [TestFixture]
    class UiObjectSerializationTests
    {
        [Test]
        public void Should_DataField_Serialized()
        {
            UiDfObject prefixDfObject = new UiDfObject("Prefijo", "100");
            prefixDfObject.DataField = "PREFIJO";
            prefixDfObject.TableName = "PROVEE2";
            prefixDfObject.LabelVisible = true;
            prefixDfObject.Height = "100";
            prefixDfObject.TextContentWidth = "100";
            prefixDfObject.PrimaryKey = "NUM_PROVEE";
            prefixDfObject.AllowedEmpty = true;
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(prefixDfObject.GetType());
            TextWriter writer = new StreamWriter(@"C:\Users\Usuario\Documents\KarveSnapshots\Karve.xml");
            serializer.Serialize(writer, prefixDfObject);
        }

        [Test]
        public void Should_UiMultipleDf_Serialized()
        {
            UiMultipleDfObject payementPlaces = new UiMultipleDfObject();
            UiDfObject dataDfObject = new UiDfObject();
            dataDfObject.LabelText = "Plazo de Pago";
            dataDfObject.DataField = "PLAZO";
            dataDfObject.TableName = "PROVEE2";
            dataDfObject.LabelTextWidth = "100";
            dataDfObject.LabelVisible = true;
            dataDfObject.Height = "100";
            dataDfObject.TextContentWidth = "50";
            dataDfObject.PrimaryKey = "NUM_PROVEE";
            dataDfObject.AllowedEmpty = true;
            payementPlaces.AddDataField(dataDfObject);
            // plazo de pago 2.

            UiDfObject dataDfObject2 = new UiDfObject();
            dataDfObject2.DataField = "PLAZO2";
            dataDfObject2.TableName = "PROVEE2";
            dataDfObject2.LabelVisible = false;
            dataDfObject2.Height = "100";
            dataDfObject2.TextContentWidth = "50";
            dataDfObject2.PrimaryKey = "NUM_PROVEE";
            dataDfObject2.AllowedEmpty = true;
            payementPlaces.AddDataField(dataDfObject2);
            // plazo de pago 3.
            UiDfObject dataDfObject3 = new UiDfObject();
            dataDfObject3.DataField = "PLAZO3";
            dataDfObject3.TableName = "PROVEE2";
            dataDfObject2.LabelVisible = false;
            dataDfObject3.Height = "100";
            dataDfObject3.TextContentWidth = "50";
            dataDfObject3.PrimaryKey = "NUM_PROVEE";
            dataDfObject3.AllowedEmpty = true;
            payementPlaces.AddDataField(dataDfObject3);
            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
   
            var xml = serializer.Serialize(payementPlaces);
            TextWriter writer = new StreamWriter(@"C:\Users\Usuario\Documents\KarveSnapshots\PayPlaces.xml");
            writer.Write(xml);
            writer.Close();

        }

        [Test]
        public void Should_Serialize_ObservableCollection()
        {
            ObservableCollection<IUiObject> obs = new ObservableCollection<IUiObject>();
            for (int i = 0; i < 10; i++)
            {
                var payementPlaces = new UiMultipleDfObject();
                UiDfObject dataDfObject = new UiDfObject
                {
                    LabelText = "Plazo de Pago",
                    DataField = "PLAZO",
                    TableName = "PROVEE2",
                    LabelTextWidth = "100",
                    LabelVisible = true,
                    Height = "100",
                    TextContentWidth = "50",
                    PrimaryKey = "NUM_PROVEE",
                    AllowedEmpty = true
                };
                payementPlaces.AddDataField(dataDfObject);
                // plazo de pago 2.

                var dataDfObject2 = new UiDfObject
                {
                    DataField = "PLAZO2",
                    TableName = "PROVEE2",
                    LabelVisible = false,
                    Height = "100",
                    TextContentWidth = "50",
                    PrimaryKey = "NUM_PROVEE",
                    AllowedEmpty = true
                };
                payementPlaces.AddDataField(dataDfObject2);
                // plazo de pago 3.
                UiDfObject dataDfObject3 = new UiDfObject();
                dataDfObject3.DataField = "PLAZO3";
                dataDfObject3.TableName = "PROVEE2";
                dataDfObject2.LabelVisible = false;
                dataDfObject3.Height = "100";
                dataDfObject3.TextContentWidth = "50";
                dataDfObject3.PrimaryKey = "NUM_PROVEE";
                dataDfObject3.AllowedEmpty = true;
                payementPlaces.AddDataField(dataDfObject3);
                obs.Add(payementPlaces);
            }
            
            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
            var xml = serializer.Serialize(obs);
            TextWriter writer = new StreamWriter(@"C:\Users\Usuario\Documents\KarveSnapshots\Observe.xml");
            writer.Write(xml);
            writer.Close();
            TextReader reader = new StreamReader(@"C:\Users\Usuario\Documents\KarveSnapshots\Observe.xml");
            string xmlValue = reader.ReadToEnd();
            var collection = serializer.Deserialize<ObservableCollection<IUiObject>>(xmlValue);

        }
    }
}
