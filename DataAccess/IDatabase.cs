using System;
namespace DataAccess
{
    public interface IDatabase
    {
        IDbDataAdapter Adapter
        {
            get;
        }
    }
}
