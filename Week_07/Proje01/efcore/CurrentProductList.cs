using System;
using System.Collections.Generic;

namespace Proje01.efcore
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
