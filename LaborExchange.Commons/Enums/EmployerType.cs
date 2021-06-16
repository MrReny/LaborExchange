using System.ComponentModel;

namespace LaborExchange.Commons
{
    public enum EmployerType
    {
        [Description("Юридическое лицо")]
        LegalEntity,

        [Description("Индивидуальный предприниматель")]
        SoleProprietor
    }
}