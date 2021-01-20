using Application.Contracts;
using Domain.Entites;

namespace Persistence.Repositories
{
    public class DataBaseRepository : BaseRepository<DataBase>, IDataBaseRepository
    {
        public DataBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


    }
}
