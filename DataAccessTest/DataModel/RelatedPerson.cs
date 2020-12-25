using System;

namespace DataAccessTest.DataModel
{
    public enum RelationType
    {
        Friend=1,
        Coworker=2
    }

    public class RelatedPerson
    {
        public RelatedPerson()
        {
        }

        public int PersonID { get; set; }
        public RelationType RelationTypeID { get; set; }
    }
}
