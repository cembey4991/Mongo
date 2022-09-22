using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Infrastructure.DBSettings.Interface
{
    public interface IMongoDatabase
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
