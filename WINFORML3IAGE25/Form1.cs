using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINFORML3IAGE25
{
    public partial class Form1 : Form
    {
        List<Personne> list = new List<Personne>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Personne personne = new Personne();
            personne.prenom = txtPrenom.Text;
            personne.nom = txtNom.Text;
            personne.tel = txtTel.Text;

            if (rbFemme.Checked)
            {
                personne.sexe = "Femme";
            }
            else
            {
                personne.sexe = "Homme";
            }
            string tempocomp = "";
            if (ckbJava.Checked)
            {
                tempocomp += "JAVA ";
            }
            if (ckbPhp.Checked)
            {
                tempocomp += "PHP ";
            }
            if (ckbCsharp.Checked)
            {
                tempocomp += "C# ";
            }
            if (ckbCplusplus.Checked)
            {
                tempocomp += "C++ ";
            }

            personne.competences = tempocomp;
            personne.classe = cmbClasse.Text;

            //save data in list
            list.Add(personne);
            MessageBox.Show("Données ajoutées ","Enregistrement",MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Chargement du dategrid view
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            effacer();
        }
        private void effacer()
        {
            txtNom.Text = String.Empty;
            txtTel.Text = String.Empty;
            txtPrenom.Text = String.Empty;

            rbFemme.Checked = false;
            rbHomme.Checked = false;

            ckbCplusplus.Checked = false;
            ckbCsharp.Checked = false;
            ckbJava.Checked = false;
            ckbPhp.Checked = false;
            cmbClasse.Text = "Selectionner";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            effacer();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }
        Personne personneselected = null;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < list.Count)
            {
                personneselected = list[e.RowIndex];
                txtNom.Text = personneselected.nom;
                txtPrenom.Text= personneselected.prenom;
                txtTel.Text= personneselected.tel;
                if (personneselected.sexe == "Femme")
                {
                    rbFemme.Checked = true;
                }
                else
                {
                    rbHomme.Checked = true;
                }

                string[] langue = personneselected.competences.Split();

                ckbCplusplus.Checked = langue.Contains("C++");
                ckbCsharp.Checked = langue.Contains("C#");
                ckbJava.Checked = langue.Contains("JAVA");
                ckbPhp.Checked = langue.Contains("PHP");

                cmbClasse.Text =personneselected.classe;
            }
        }
    }
}
