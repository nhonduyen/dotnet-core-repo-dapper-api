

namespace mydapper.Repository
{
    public class DatabaseOptions
    {
        public static DatabaseOptions Current;
      
        public DatabaseOptions()
        {
            Current = this;
        }
    }
}