using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.Repositories
{
    public class SeatRepository<T> : Repository<Seat>
    {
        public SeatRepository(IDataConnection dataConnection) 
            : base(dataConnection) { }


    }
}
