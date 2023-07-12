using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApi.Database.Migrations
{
    public static class MigrationVersioning
    {
        internal const long MaxVersion = CreateCustomerTable;

        public const long CreateCustomerTable = 1;
    }
}
