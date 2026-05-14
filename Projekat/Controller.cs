using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Projekat
{
    //fda
    public class Controller
    {
        private DBBroker db = new DBBroker();

        public List<Dobavljac> VratiDobavljace()
        {
            db.OpenConnection();
            List<Dobavljac> lista = db.VratiSveDobavljace();
            db.CloseConnection();
            return lista;
        }

        public List<Proizvod> VratiProizvode(int dobavljacID)
        {
            db.OpenConnection();
            List<Proizvod> lista = db.VratiProizvodePoDobavljacu(dobavljacID);
            db.CloseConnection();
            return lista;
        }

        public void InsertProizvod(Proizvod p)
        {
            db.OpenConnection();
            db.InsertProizvod(p);
            db.CloseConnection();
        }

        public void DeleteProizvod(int proizvodID)
        {
            db.OpenConnection();
            db.DeleteProizvod(proizvodID);
            db.CloseConnection();
        }

        public void UpdateProizvodi(List<Proizvod> proizvodi)
        {
            db.OpenConnection();
            db.UpdateProizvodi(proizvodi);
            db.CloseConnection();
        }
    }
}
