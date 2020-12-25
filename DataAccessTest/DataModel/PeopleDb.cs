using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess;
using DataAccess.Mocks;

namespace DataAccessTest.DataModel
{
    public class PeopleDb : DatabaseBase
    {
        public PeopleDb(IDbDataAdapter adapter) : base(adapter)
        {
            Person = new Table<Person>(adapter);

            // Or should this be determined by reading the db schema?
            MockDbMetaRepository.Table<Person>()
                                   .SetSchema("dbo")
                                   .RegisterIdentityColumn(p => p.ID);
        }

        public Table<Person> Person { get; set; }

        public void spAddWorkHistory(int PersonID, string JobTitle, string CompanyName)
        {
            Execute("spAddWorkHistory", PersonID, JobTitle, CompanyName);
        }

        public IEnumerable<RelatedPerson> spGetRelatedPeople(int PersonID)
        {
            return Execute<RelatedPerson>("spGetRelatedPeople", PersonID);
        }
    }
}
