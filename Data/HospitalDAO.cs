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
    public class HospitalDAO
    {
        Conexao con = new Conexao();

        public static List<Hospital> GetHospital()
        {
            using (IDbConnection conn = new Conexao().conn)
            {
                var output = conn.Query<Hospital>("Select * from HospitalCadastro", new DynamicParameters());
                return output.ToList();
            }
        }

        public static Hospital GetHospital(int id)
        {
            using (IDbConnection conn = new Conexao().conn)
            {
                var output = conn.Query<Hospital>("SELECT * FROM HospitalCadastro WHERE Id = " + id, new DynamicParameters());
                return output.First();
            }
        }

        public static void InsereHospital(Hospital hospital)
        {
            using (IDbConnection conn = new Conexao().conn)
            {
                conn.Execute("INSERT INTO HospitalCadastro(Endereco, NumEndereco, Nome, Especializacao, Cnpj) " +
                    "VALUES(@Endereco, @NumEndereco, @Nome, @Especializacao, @Cnpj)", hospital);
            }
        }

        public static void AtualizaHospital(Hospital hospital)
        {
            using (IDbConnection conn = new Conexao().conn)
            {
                conn.Execute("UPDATE Alunos SET Endereco=@Endereco, NumEndereco=@NumEndereco, Nome=@Nome, Especializacao=@Especializacao, Cnpj=@Cnpj WHERE Id=@Id", hospital);
            }
        }

        public static void DeleteHospital(Hospital hospital)
        {
            using (IDbConnection conn = new Conexao().conn)
            {
                conn.Execute("DELETE FROM HospitalCadastro WHERE Id=@Id", hospital);
            }
        }
    }
}