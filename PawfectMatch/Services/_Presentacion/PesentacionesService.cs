using PawfectMatch.Migrations;
using System.Linq.Expressions;

namespace PawfectMatch.Services._Presentacion
{
    public class PesentacionesService : ICRUD<Presentaciones>
    {
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Presentaciones elem)
        {
            throw new NotImplementedException();
        }

        public Task<List<Presentaciones>> ListAsync(Expression<Func<Presentaciones, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(Presentaciones elem)
        {
            throw new NotImplementedException();
        }

        public Task<Presentaciones> SearchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Presentaciones elem)
        {
            throw new NotImplementedException();
        }
    }
}
