using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            refresh();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(personneselected == null)
            {
                MessageBox.Show("Verifier que vous avez selectionner","Avertissement",MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = MessageBox.Show("Voulez vous confirmer la suppression", "Avertissement",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    list.Remove(personneselected);
                    refresh();
                    effacer();
                }
                
            }
            
        }
        public void refresh()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (personneselected == null)
            {
                MessageBox.Show("Verifier que vous avez selectionner", "Avertissement", MessageBoxButtons.OK);
            }
            else
            {
                int pos = list.IndexOf(personneselected);
                personneselected.tel = txtTel.Text;
                personneselected.nom = txtNom.Text;
                personneselected.prenom = txtPrenom.Text;

                personneselected.sexe = (rbFemme.Checked) ? "Femme" : "Homme";

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
                personneselected.competences = tempocomp;
                personneselected.classe = cmbClasse.Text;

                list[pos] = personneselected;
                refresh();
                effacer(); 

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
