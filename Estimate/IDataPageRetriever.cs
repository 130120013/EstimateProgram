using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimate
{
    public interface IDataPageRetriever
    {
        DataTable SupplyPageOfData(long lowerPageBoundary, long rowsPerPage);
    }
}
