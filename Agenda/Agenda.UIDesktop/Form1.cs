
using Microsoft.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeNovo.Text;
            string id = Guid.NewGuid().ToString();
            //txtNomeSalvo.Text = nome;
            string strCon = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=Agenda;Integrated Security = True; TrustServerCertificate=True";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            var sql = String.Format("insert into Contato (Id,Nome) values ('{0}','{1}')", id, nome);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            sql = String.Format("select Nome from Contato where Id= '{0}'", id);
            cmd = new SqlCommand(sql, con);
            var ret = cmd.ExecuteScalar().ToString();
            txtNomeSalvo.Text = ret;
            con.Close();
        }
    }
}
