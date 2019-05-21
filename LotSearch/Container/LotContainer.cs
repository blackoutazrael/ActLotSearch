using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotSearch.Container
{
    class LotContainer
    {
        public string ITEM { get; set; }
        public string JOB { get; set; }
        public string USER { get; set; }
        public string EQUIPNAME { get; set; }
        public bool IS_FIRST_PRIORITY { get; set; } = true;
    }
}
