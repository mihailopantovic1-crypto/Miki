using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Projekat
{
    public class DBBroker
    {
        private SqlConnection connection;

        public DBBroker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProdavnicaDB;Integrated Security=True");
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        public List<Dobavljac> VratiSveDobavljace()
        {
            List<Dobavljac> lista = new List<Dobavljac>();

            SqlCommand cmd = new SqlCommand("vratiSveDobavljace", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dobavljac d = new Dobavljac();
                d.DobavljacID = (int)reader["DobavljacID"];
                d.Naziv = (string)reader["Naziv"];
                d.Adresa = (string)reader["Adresa"];
                d.Telefon = (string)reader["Telefon"];

                lista.Add(d);
            }

            reader.Close();
            return lista;
        }

        public List<Proizvod> VratiProizvodePoDobavljacu(int dobavljacID)
        {
            List<Proizvod> lista = new List<Proizvod>();

            SqlCommand cmd = new SqlCommand("vratiProizvodePoDobavljacu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DobavljacID", dobavljacID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Proizvod p = new Proizvod();
                p.ProizvodID = (int)reader["ProizvodID"];
                p.Naziv = (string)reader["Naziv"];
                p.Cena = (decimal)reader["Cena"];
                p.Kolicina = (int)reader["Kolicina"];
                p.DobavljacID = (int)reader["DobavljacID"];

                lista.Add(p);
            }

            reader.Close();
            return lista;
        }

        public void InsertProizvod(Proizvod p)
        {
            SqlCommand cmd = new SqlCommand("ubaciProizvod", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Naziv", p.Naziv);
            cmd.Parameters.AddWithValue("@Cena", p.Cena);
            cmd.Parameters.AddWithValue("@Kolicina", p.Kolicina);
            cmd.Parameters.AddWithValue("@DobavljacID", p.DobavljacID);

            cmd.ExecuteNonQuery();
        }

        public void DeleteProizvod(int proizvodID)
        {
            SqlCommand cmd = new SqlCommand("obrisiProizvod", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProizvodID", proizvodID);

            cmd.ExecuteNonQuery();
        }

        public void UpdateProizvodi(List<Proizvod> proizvodi)
        {
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                foreach (Proizvod p in proizvodi)
                {
                    SqlCommand cmd = new SqlCommand("azurirajProizvod", connection, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProizvodID", p.ProizvodID);
                    cmd.Parameters.AddWithValue("@Naziv", p.Naziv);
                    cmd.Parameters.AddWithValue("@Cena", p.Cena);
                    cmd.Parameters.AddWithValue("@Kolicina", p.Kolicina);

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
