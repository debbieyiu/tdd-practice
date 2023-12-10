using System;

namespace ParserTool.Libraries.Models
{
    public class RelatedDepositOnlineTypesAttribute : Attribute
    {
        public RelatedDepositOnlineTypesAttribute(params PaymentOnlineType[] onlineTypes)
        {
            OnlineTypes = onlineTypes;
        }

        public PaymentOnlineType[] OnlineTypes { get; }
    }
}