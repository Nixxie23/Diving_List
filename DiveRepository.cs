using Diving_List.Models;
using System.Data;
using Dapper;

namespace Diving_List
{
    public class DiveRepository : IDiveRepository
    {
        private readonly IDbConnection _conn;
        public DiveRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Dive> GetAllDives()
        {
            return _conn.Query<Dive>("SELECT * FROM ONEMETER;");
        }
        public Dive GetDive (int id)
        {
            return _conn.QuerySingle<Dive>("SELECT * FROM ONEMETER WHERE DIVENO = @id", new { id = id });
        }
    }
}
