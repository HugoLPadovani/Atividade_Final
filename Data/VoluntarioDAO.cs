using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.Model;
using Dapper;
using System.Data;

namespace Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.Data
{
    class VoluntarioDAO
    {
        Conexao con = new Conexao();

        public static Voluntario GetVoluntario(int id)
        {
            using (IDbConnection conn = new Conexao().conn)
            {
                var output = conn.Query<Voluntario>("SELECT * FROM Voluntarios WHERE Id = " + id, new DynamicParameters());
                return output.First();
            }
        }

        internal static object GetVoluntario()
        {
            throw new NotImplementedException();
        }
    }
}
