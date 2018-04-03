using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLayer.SQL;
using NUnit.Framework;

namespace KarveTest.DAL
{
    [TestFixture]
    class TestSqlQuery
    {

        private DataCollection MakeVehicleDataCollection()
        {
            DataCollection collection = new DataCollection();
            Table table = new Table();
            ;
            table.Name = "VEHICULO1";
            table.AddField(new Field("marca"));
            table.AddField(new Field("matricula"));
            table.AddField(new Field("modelo"));
            table.AddField(new Field("grupo"));
            table.AddField(new Field("mar"));
            table.AddField(new Field("color"));
            table.AddField(new Field("proveedor"));
            table.AddField(new Field("tiposegu"));
            collection.AddTable(table);
            Table table2 = new Table();
            table2.Name = "VEHICULO2";
            table2.AddField(new Field("gastos"));
            table2.AddField(new Field("km"));
            table2.AddField(new Field("saldo"));
            collection.AddTable(table2);
            return collection;

        }
        private DataCollection MakeDataCollection()
        {
            DataCollection collection = new DataCollection();
            Table table = new Table();
            table.Name = "COMISIO";
            table.AddField(new Field("cp"));
            table.AddField(new Field("direccion"));
            table.AddField(new Field("poblacion"));
            table.AddField(new Field("provincia"));
            table.AddField(new Field("nacioper"));
            table.AddField(new Field("telefono"));
            table.AddField(new Field("fax"));
            table.AddField(new Field("movil"));
            table.AddField(new Field("alta_comi"));
            table.AddField(new Field("baja_comi"));
            table.AddField(new Field("idioma"));
            table.AddField(new Field("iata"));
            table.AddField(new Field("ivasino"));
            table.AddField(new Field("retensino"));
            table.AddField(new Field("nacional"));
            table.AddField(new Field("conceptos_cond"));
            table.AddField(new Field("agencia"));
            table.AddField(new Field("traduce_ws"));
            table.AddField(new Field("truck_rental_broker"));
            table.AddField(new Field("combus_prepago_comi"));
            table.AddField(new Field("no_generar_autofac"));
            table.AddField(new Field("todos_extras"));
            table.AddField(new Field("auto_oneway"));
            table.AddField(new Field("COT_INCLUIDOS_SIN_GRUPO"));
            table.AddField(new Field("no_mail_res"));
            table.AddField(new Field("autofac_sin_iva"));
            table.AddField(new Field("commision_sin_iva_com"));
            table.AddField(new Field("num_sobreque"));
            table.AddField(new Field("porcen"));
            table.AddField(new Field("porcenlo"));
            table.AddField(new Field("porcencl"));
            table.AddField(new Field("por_subcontra"));
            table.AddField(new Field("imp_comi"));
            table.AddField(new Field("ref_a_cli"));
            table.AddField(new Field("cliente"));
            table.AddField(new Field("product_comi"));
            table.AddField(new Field("nif"));
            table.AddField(new Field("email"));
            collection.AddTable(table);
            return collection;
        }
        [Test]
        public void Should_CreateAnd_LoadFields()
        {
           var path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
           
           DataCollection collection = new DataCollection();
           Table table = new Table();
           table.Name = "COMISIO";
           table.AddField(new Field("cp"));
           table.AddField(new Field("direccion"));
           table.AddField(new Field("poblacion"));
           table.AddField(new Field("provincia"));
           table.AddField(new Field("nacioper"));
           table.AddField(new Field("telefono"));
           table.AddField(new Field("fax"));
           table.AddField(new Field("movil"));
           table.AddField(new Field("alta_comi"));
           table.AddField(new Field("baja_comi"));
           table.AddField(new Field("idioma"));
           table.AddField(new Field("iata"));
           table.AddField(new Field("ivasino"));
           table.AddField(new Field("retensino"));
           table.AddField(new Field("nacional"));
           table.AddField(new Field("conceptos_cond"));
           table.AddField(new Field("agencia"));
           table.AddField(new Field("traduce_ws"));
           table.AddField(new Field("truck_rental_broker"));
           table.AddField(new Field("combus_prepago_comi"));
           table.AddField(new Field("no_generar_autofac"));
           table.AddField(new Field("todos_extras"));
           table.AddField(new Field("auto_oneway"));
           table.AddField(new Field("COT_INCLUIDOS_SIN_GRUPO"));
           table.AddField(new Field("no_mail_res"));
           table.AddField(new Field("autofac_sin_iva"));
           table.AddField(new Field("commision_sin_iva_com"));
           table.AddField(new Field("num_sobreque"));
           table.AddField(new Field("porcen"));
           table.AddField(new Field("porcenlo"));
           table.AddField(new Field("porcencl"));
           table.AddField(new Field("por_subcontra"));
           table.AddField(new Field("imp_comi"));
           table.AddField(new Field("ref_a_cli"));
           table.AddField(new Field("cliente"));
           table.AddField(new Field("product_comi"));
           table.AddField(new Field("nif"));
           table.AddField(new Field("email"));
           collection.AddTable(table);
            DataLoader loader = new DataLoader();
            StringBuilder builder = new StringBuilder();
            Uri fileUri = new Uri(path);

            builder.Append(fileUri.LocalPath);
            builder.Append("\\CommissionAgent.xml");
            string savedPathFile = builder.ToString();
            // we save the data to xml.
            try
            {
                loader.SaveXmlData(collection, savedPathFile);
                // now we shall load the fields from the data contained.
            }
            catch (Exception e)
            { 
                Console.Write(e.Message);
                Assert.Fail(e.Message);
            }
            // ok now we have to load the data from disk again.
            DataCollection newCollection = loader.LoadXmlData(savedPathFile);
            Assert.NotNull(newCollection);
            bool equalList = CompareEqualList(newCollection.DataList, collection.DataList);
            Assert.IsTrue(equalList);
        }
        /// <summary>
        /// This is a valid sql to be returned.
        /// </summary>
        [Test]
        public  void Shall_Return_A_Valid_SQL()
        {
            string sqlStr = SqlQueryGenerate();
            Assert.AreEqual(sqlStr.Length, 433);
        }
        /// <summary>
        /// SqlQuery generate.
        /// </summary>
        /// <returns></returns>
        private string SqlQueryGenerate()
        {
            DataCollection collection = MakeDataCollection();
            string tableName = collection.DataList[0].Name;
            Assert.NotNull(tableName);
            List<Field> fieldList = collection.DataList[0].DataFields;
            StringBuilder builder = new StringBuilder();
            foreach (var field in fieldList)
            {
                builder.Append(field.Name);
                builder.Append(",");
            }
            string fields = builder.ToString();
            fields= fields.Substring(0, fields.Length - 1);
            builder.Clear();
            builder.Append("SELECT ");
            builder.Append(fields);
            builder.Append(" FROM ");
            builder.Append(tableName);
            string value = builder.ToString();
           
            Assert.NotNull(value);
            return value;
        }
        /// <summary>
        /// This is a compare list between two lists.
        /// </summary>
        /// <param name="dataList1">TableList 1 </param>
        /// <param name="dataList2">Table list 2.</param>
        /// <returns></returns>
        private bool CompareEqualList(IList<Table> dataList1, IList<Table> dataList2)
        {
            if (dataList1.Count != dataList2.Count)
                return false;
            foreach (Table table in dataList1)
            {
                IDictionary<string, Field> currentDataField = new Dictionary<string, Field>();

                foreach (var fields in table.DataFields)
                {
                    currentDataField.Add(fields.Name, fields);
                }

                foreach (var tables in dataList2)
                {
                    foreach (var fields in tables.DataFields)
                    {
                        if (!currentDataField.ContainsKey(fields.Name))
                        {
                            return false;
                        }
                    }

                }
                
            }
            return true;
        }
    }
}
