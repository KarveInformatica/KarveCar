using DataAccessLayer.Logic;

namespace DataAccessLayer
{
    public class MarcasDAL: GenericDAL
    {

        #region "   .   CONSTRUCTOR.    "

        public MarcasDAL()
        {
            LoadRulesAdd();
            LoadRulesModi();
            LoadRulesDel();
        }

        #endregion

        #region "   .   DEFINICION RULES.    "

        private void LoadRulesAdd()
        {
        }

        private void LoadRulesModi()
        {
            RulesMod.Add(RuleCodigo());
            RulesMod.Add(RuleNombre());        
        }

        private void LoadRulesDel()
        {
        }

        #endregion


        #region "   .   RULES INDIVIDUALES.    "

        private RuleDAL RuleCodigoExistente()
        {
            RuleDAL RL = new RuleDAL();
            RL.BdTable = "MARCAS";
            RL.BdField = "CODIGO";
            RL.ColumnName_Ext = "CODIGO";
            RL.TableName_Ext = "MARCAS";
            RL.Comparacion = RuleDAL.Comparaciones.Igual;
            RL.Message = "El campo Código ya Existe.";
            return RL;
        }

        private RuleDAL RuleCodigo()
            {
            RuleDAL RL = new RuleDAL();
                RL.BdTable = "MARCAS";
                RL.BdField = "CODIGO";
                RL.Comparacion = RuleDAL.Comparaciones.Distinto;
                RL.ValueCompara = "";
                RL.Message = "El campo Código no puede ser vacío.";
            return RL;
            }

        private RuleDAL RuleNombre()
            {
                RuleDAL RL = new RuleDAL();
                RL.BdTable = "MARCAS";
                RL.BdField = "NOMBRE";
                RL.Comparacion = RuleDAL.Comparaciones.Distinto;
                RL.ValueCompara = "";
                RL.Message = "El campo Nombre no puede ser vacío.";
                return RL;
            }        

        #endregion
    }
}
