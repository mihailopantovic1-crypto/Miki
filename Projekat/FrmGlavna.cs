using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Projekat
{
    //miki komentar
    public partial class FrmGlavna : Form
    {
        Controller controller = new Controller();
        bool editMode = false;

        public FrmGlavna()
        {
            //xexe dtdh
            InitializeComponent();
        }

        private void FrmGlavna_Load(object sender, EventArgs e)
        {
            UcitajDobavljace();

            dgvProizvodi.DataSource = null;

            dgvDobavljaci.ReadOnly = true;
            dgvProizvodi.ReadOnly = true;

            dgvDobavljaci.RowHeadersVisible = false;
            dgvProizvodi.RowHeadersVisible = false;

            dgvProizvodi.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvProizvodi.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvProizvodi.AllowUserToAddRows = false;
        }

        private void UcitajDobavljace()
        {
            dgvDobavljaci.DataSource = controller.VratiDobavljace();
            dgvDobavljaci.Columns["DobavljacID"].Visible = false;
        }

        private void dgvDobavljaci_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDobavljaci.CurrentRow != null)
            {
                Dobavljac d = (Dobavljac)dgvDobavljaci.CurrentRow.DataBoundItem;
                dgvProizvodi.DataSource = controller.VratiProizvode(d.DobavljacID);

                dgvProizvodi.Columns["ProizvodID"].Visible = false;
                dgvProizvodi.Columns["DobavljacID"].Visible = false;
            }
        }

        private void miInsert_Click(object sender, EventArgs e)
        {
            Dobavljac d;
            string naziv;
            decimal cena;
            int kolicina;

            if (!InsertValidation(out d, out naziv, out cena, out kolicina))
            {
                return;
            }

            Proizvod p = new Proizvod();
            p.Naziv = naziv;
            p.Cena = cena;
            p.Kolicina = kolicina;
            p.DobavljacID = d.DobavljacID;

            controller.InsertProizvod(p);

            RefreshGridovi();
            MessageBox.Show("Proizvod je uspesno dodat.");
        }

        private bool InsertValidation(out Dobavljac d, out string naziv, out decimal cena, out int kolicina)
        {
            if (dgvDobavljaci.CurrentRow == null)
            {
                MessageBox.Show("Izaberite dobavljaca.");
                d = new Dobavljac();
                naziv = string.Empty;
                cena = 0M;
                kolicina = 0;
                return false;
            }

            d = (Dobavljac)dgvDobavljaci.CurrentRow.DataBoundItem;
            naziv = Interaction.InputBox("Unesite naziv proizvoda:", "Insert proizvoda", "");
            if (string.IsNullOrWhiteSpace(naziv))
            {
                MessageBox.Show("Naziv je obavezan.");
                d = new Dobavljac();
                naziv = string.Empty;
                cena = 0M;
                kolicina = 0;
                return false;
            }

            string cenaTekst = Interaction.InputBox("Unesite cenu proizvoda:", "Insert proizvoda", "");
            if (!decimal.TryParse(cenaTekst, out cena))
            {
                MessageBox.Show("Cena mora biti broj.");
                d = new Dobavljac();
                naziv = string.Empty;
                cena = 0M;
                kolicina = 0;
                return false;
            }

            string kolicinaTekst = Interaction.InputBox("Unesite kolicinu proizvoda:", "Insert proizvoda", "");
            if (!int.TryParse(kolicinaTekst, out kolicina))
            {
                MessageBox.Show("Kolicina mora biti ceo broj.");
                return false;
            }

            return true;
        }

        private void RefreshGridovi()
        {
            int selektovaniDobavljacID = -1;

            if (dgvDobavljaci.CurrentRow != null)
            {
                Dobavljac selektovani = (Dobavljac)dgvDobavljaci.CurrentRow.DataBoundItem;
                selektovaniDobavljacID = selektovani.DobavljacID;
            }

            dgvDobavljaci.DataSource = controller.VratiDobavljace();
            dgvDobavljaci.Columns["DobavljacID"].Visible = false;

            if (selektovaniDobavljacID != -1)
            {
                foreach (DataGridViewRow red in dgvDobavljaci.Rows)
                {
                    Dobavljac d = (Dobavljac)red.DataBoundItem;
                    if (d.DobavljacID == selektovaniDobavljacID)
                    {
                        red.Selected = true;
                        dgvDobavljaci.CurrentCell = red.Cells["Naziv"];
                        break;
                    }
                }

                dgvProizvodi.DataSource = controller.VratiProizvode(selektovaniDobavljacID);
                dgvProizvodi.Columns["ProizvodID"].Visible = false;
                dgvProizvodi.Columns["DobavljacID"].Visible = false;
            }
            else
            {
                dgvProizvodi.DataSource = null;
            }
        }

        private void miUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProizvodi.DataSource == null)
            {
                MessageBox.Show("Nema proizvoda za izmenu.");
                return;
            }

            if (!editMode)
            {
                dgvProizvodi.ReadOnly = false;
                dgvProizvodi.Columns["ProizvodID"].ReadOnly = true;
                dgvProizvodi.Columns["DobavljacID"].ReadOnly = true;

                editMode = true;
                MessageBox.Show("Grid je otkljucan. Kliknite levim klikom u polje i izmenite vrednost. Kada zavrsite, desni klik pa opet Update.");
            }
            else
            {
                dgvProizvodi.EndEdit();

                List<Proizvod> lista = (List<Proizvod>)dgvProizvodi.DataSource;
                controller.UpdateProizvodi(lista);

                dgvProizvodi.ReadOnly = true;
                editMode = false;

                RefreshGridovi();

                MessageBox.Show("Izmene su uspesno sacuvane.");
            }
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            if (dgvProizvodi.CurrentRow == null)
            {
                MessageBox.Show("Izaberite proizvod.");
                return;
            }

            Proizvod p = (Proizvod)dgvProizvodi.CurrentRow.DataBoundItem;

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da zelite da obrisete proizvod?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rezultat == DialogResult.Yes)
            {
                controller.DeleteProizvod(p.ProizvodID);
                RefreshGridovi();
                MessageBox.Show("Proizvod je obrisan.");
            }
        }
    }
}