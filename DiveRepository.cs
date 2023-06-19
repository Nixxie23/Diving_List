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
        public void UpdateNotes(Dive dive)
        {
            _conn.Execute("UPDATE onemeter SET Notes = @notes WHERE DiveNo = @id",
             new { notes = dive.Notes, id = dive.DiveNo});
        }
   
        public void InsertDive(Dive newDive)
        {
          
                _conn.Execute("INSERT INTO onemeter (DiveNo, Name, CTuck, BPike, AStraight, DFree ) VALUES (@diveno, @name, @ctuck, @bpike, @astraight, @dfree);",
                    new { diveno = newDive.DiveNo, name = newDive.Name, ctuck = newDive.CTuck, bpike = newDive.BPike, astraight = newDive.AStraight, dfree = newDive.DFree });

           
        }

        
        

    }
}
