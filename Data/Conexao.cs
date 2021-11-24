using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Trabalho_Final___Desenvolvimento_de_Sistemas_de_Informação.Data
{
    public class Conexao
    {
        public SQLiteConnection conn = new SQLiteConnection("Data Source = Hospital.db");

        public void conectar()
        {
            conn.Open();
        }
        public void desconectar()
        {
            conn.Close();
        }
    }
}
