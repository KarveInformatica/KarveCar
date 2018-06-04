using System;
using DevExpress.Xpo;

namespace KarveCommonInterfaces
{

    public class IPayloadFactory : XPObject
    {
        public IPayloadFactory() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public IPayloadFactory(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }

}