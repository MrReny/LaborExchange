using System.ComponentModel;

namespace LaborExchange.Commons
{
    public enum Education
    {
        [Description("Без оброзования")]
        NoEducation = 0,

        [Description("Школьное оброзование")]
        LowEducation = 1,

        [Description("Среднее оброзование")]
        MiddleEducation = 2,

        [Description("Высшее ооброзование")]
        HighEducation = 3
    }
}