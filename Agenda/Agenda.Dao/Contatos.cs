
using Agenda.Domain;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Agenda.Dao
{
    public class Contatos
    {

        string _strCon;       
        public Contatos()
        {
            //precisa colocar no app.config
            _strCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=AgendaTeste;Integrated Security = True; TrustServerCertificate=True;";//
            //var connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            //Console.WriteLine(connStr);
        }

        

        public void Adicionar(Contato contato)
        {
            using(var con = new SqlConnection(_strCon)) {
                con.Execute("insert into Contato (Id,Nome) values (@Id,@Nome)", contato);
       
            }
        }



        public Contato Obter(string id)
        {
            Contato contato;

            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("select Id,Nome from Contato where Id= @Id", new { Id = id });

            }
            

            return contato;
        }

        public IList<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();
            using (var con = new SqlConnection(_strCon))
            {
                contatos = con.Query<Contato>("select Id,Nome from Contato").ToList();

                // parte sem o Dapper 
                //var sql = @"select Id,Nome from Contato";
                //con.Open();
                //var cmd = new SqlCommand(sql, con);
                //var retsqlDataReader = cmd.ExecuteReader();
                //while (retsqlDataReader.Read())
                //{
                //    var contato = new Contato()
                //    {
                //        Id = Guid.Parse(retsqlDataReader["Id"].ToString()),
                //        Nome = retsqlDataReader["Nome"].ToString()
                //    };
                //    contatos.Add(contato);
                //}
            }
           
            return contatos;
        }
    }
}

