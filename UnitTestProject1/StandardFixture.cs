using Zoo.Infrastructure.DataAcces;
using Zoo.Infrastructure.EntityFrameworkDataAccess;
using Zoo.Infrastructure.EntityFrameworkDataAccess.Repositories;

namespace UnitTestProject1
{
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            this.EntityFactory = new EntityFactory();
            this.DataContextFake = new DataContextFake();
            this.AnimalRepositoryFake = new AnimalRepositoryFake();
            
        }
        public EntityFactory EntityFactory { get; }
        public DataContextFake DataContextFake { get; }
        public AnimalRepositoryFake AnimalRepositoryFake { get; }


    }
}
