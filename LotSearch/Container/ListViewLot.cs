using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotSearch.Container
{
    class LotListViewContainer
    {
        public string WHO { get; set; }
        public string LOT { get; set; }
        public string ITEM { get; set; }
        
        public string[] toArray() => new string[]{this.WHO, this.LOT, this.ITEM};
    }
}
