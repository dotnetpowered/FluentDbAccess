using System;


namespace DataAccess.Mocks
{
    public class MockDbMetaRepository
    {
        public MockDbMetaRepository()
        {
        }

        public static MockTableMetaData<T> Table<T>() where T : class
        {
            return new MockTableMetaData<T>();
        }
    }
}
