using Microsoft.Data.SqlClient;
using NUnit.Framework;
using System.Configuration;

namespace Agenda.Dao.Test
{
    [TestFixture]
    public class BaseTest
    {
        private readonly string _strCon;
        private string _script;
        private string _catalogTest;

        public BaseTest()
        {
            
            _script = @"DBAgenda_Create.sql";

            // Cria uma instância da classe AppSettings
            var appSettings = new AppSettingsTests();

            // Usa a classe AppSettings para obter a string de conexão e providerName
            _strCon = appSettings.GetConnectionString("connectionSetupTest");
            _catalogTest = appSettings.GetProviderName("connectionSetupTest");

            

        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            CreateDBTest();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeleteDBTest();
        }

        private void CreateDBTest()
        {
            var appBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            using (var con = new SqlConnection(_strCon))
            {
                con.Open();
                var scriptSql = File
                    .ReadAllText($@"{appBase}\{_script}")
                    .Replace("$(DefaultDataPath)", $@"{appBase}")
                    .Replace("$(DefaultLogPath)", $@"{appBase}")
                    .Replace("$(DefaultFilePrefix)", _catalogTest)
                    .Replace("$(DatabaseName)", _catalogTest)
                    .Replace("WITH (DATA_COMPRESSION = PAGE)", string.Empty)
                    .Replace("SET NOEXEC ON", string.Empty)
                    .Replace("GO\r\n", "|");

                ExecuteScriptSql(con, scriptSql);
            }
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using (var cmd = con.CreateCommand())
            {
                var teste = scriptSql.Split('|');
                foreach (var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;

                    //Essa linha irá ignora as linhas que contem ':' como :setvar ou :on error etc
                    //No nosso caso, não irá fazer diferença.
                    if (sql.Contains(':'))
                        continue;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        DeleteDBTest();
                        Console.WriteLine(sql);
                        Console.WriteLine(e.Message);
                        throw e;
                    }

                }
            }
        }

        private void DeleteDBTest()
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {
                    //Irá mudar para Base Master
                    cmd.CommandText = $@"USE [master]";
                    cmd.ExecuteNonQuery();

                    //String com a quey para buscar todas as sessões da base de teste.
                    cmd.CommandText = $@"SELECT session_id AS Id
                                         FROM sys.dm_exec_sessions
                                         WHERE database_id = db_id('{_catalogTest}')";

                    //Irá realizar a leitura na Base Master
                    var reader = cmd.ExecuteReader();

                    //Criação de uma lista para pôr os Ids
                    var ids = new List<int>();

                    //Leitura dos Ids porque pode ocorrer de ter mais de uma sessão para AgendaTest
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt16(0));
                    }
                    //Fechando o SqlDataReader
                    reader.Close();

                    //Irá dar o comando kill para cada id
                    foreach (var id in ids)
                    {
                        cmd.CommandText = $@"kill {id}";
                        cmd.ExecuteNonQuery();
                    }

                    //Irá dropar a Base de teste.
                    cmd.CommandText = $"DROP DATABASE {_catalogTest}";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}