using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.Util.Repository
{
    public interface IEntity<ID>
    {
        public ID Id { get; set; }
    }
}
