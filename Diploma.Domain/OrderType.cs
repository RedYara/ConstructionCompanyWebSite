using System.ComponentModel;

namespace Diploma.Domain
{
    public enum OrderType : int
    {
        [Description("Здание")]
        Building = 0,

        [Description("Товар")]
        Product = 1
    }
}
