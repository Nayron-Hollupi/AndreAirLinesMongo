using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PriceBaseView
    {
        #region Properties
        public virtual string Origin { get; set; }
        public virtual string Destination { get; set; }
        public decimal Value { get; set; }
        public DateTime InclusionDate { get; set; }
        #endregion
    }
}
