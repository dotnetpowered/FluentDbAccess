using System;
using DataAccess;
using System.Data.SqlClient;
using DataAccessTest.DataModel;

namespace DataAccessTest
{
    class Program
    {
        // TODO: chain state through classes within a method chain
        // TODO: recursive object saving
        // TODO: recursive object selection
        static void Main(string[] args)
        {
            var db2 = new PeopleDb(new DataAccess.Mocks.MockDbAdapter());
            db2.Person.Insert(new Person { FirstName = "test", LastName = "name" });

            // Call custom stored proc (added to PeopleDb)
            db2.spAddWorkHistory(1, "Programmer/Analyst", "Disney");

            // Call custom stored proc with results (added to PeopleDb)
            var people = db2.spGetRelatedPeople(1);
            foreach (var p in people)
            {
                Console.WriteLine("{0}: {1}", p.PersonID, p.RelationTypeID);
            }

            db2.Person.Update.Set(p => p.FirstName).To("dog").Where(p => p.Age).Is(10).Execute();




            var db = new Database(new DataAccess.Mocks.MockDbAdapter());

            // Insert single record
            var catBert = new Person { FirstName = "Cat", LastName = "Bert", Age = 5 };
            db.InsertInto<Person>(catBert)
             .Execute();

            // Insert multiple records
            db.InsertInto<Person>(new [] {
                                    new Person { FirstName = "Sam", LastName = "Jones", Age = 20 },
                                    new Person { FirstName = "Dog", LastName = "Bert", Age = 10 }
                                })
             .Execute();

            // Merge (Upsert) single record
            var UpdatedSam = new Person { ID = 1, FirstName = "Samuel", LastName = "Jones", Age = 5 };
            db.MergeInto<Person>(UpdatedSam)
             .On(p=>p.ID)
             .Execute();

            // Merge (Upsert) multiple records
            var UpdateRecords = new [] {
                new Person { ID = 1, FirstName = "Samuel", LastName = "Jones", Age = 5 },
                new Person { ID = 2, FirstName = "Doggy", LastName = "Bert", Age = 10 }
            };
            db.MergeInto<Person>(UpdateRecords)
             .On(p => p.ID)
             .Execute();

            // Update records
            db.Update<Person>()
             .Set(p => p.FirstName).To("Cow")
             .Where(p => p.FirstName).Is("Cat")
             .Execute();

            // Update records and get # of rows affected
            var rowsAffected = db.Update<Person>()
                                .Set(p => p.FirstName).To(null)
                                .Where(p => p.LastName).Is(null)
                                .Execute();

            // Delete records
            db.DeleteFrom<Person>()
             .Where(p => p.ID).Is(1)
             .Execute();

            // Select all records
            var list2 = db.SelectFrom<Person>()
                         .AsList();
            
            // Select records with where clause
            var list = db.SelectFrom<Person>()
                        .Where(p => p.Age).GreaterThan(3)
                        .AsList();

            // Find single record
            var item = db.Find<Person>()
                        .Where(p => p.ID).Is(10)
                        .Value();


        }
    }
}
