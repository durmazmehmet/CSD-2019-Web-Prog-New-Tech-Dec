using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.CarInfoApp.Models
{
    public partial class CarInfo : ICloneable
    {
        public override bool Equals(object obj) => ((CarInfo)obj).Id == Id;
     
        public override int GetHashCode() => base.GetHashCode();

        public object Clone() => new CarInfo { Id = Id, Brand = Brand, Date = Date, EngineId = EngineId, Model = Model };
       
    }
}
