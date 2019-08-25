﻿using Banco_de_Horas.bd;
using Banco_de_Horas.modelo;
using Bancod_de_Horas.bd;
using Bancod_de_Horas.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_de_Horas
{
    public partial class Form2 : Form
    {
        private string codigo;
        private FuncionarioBd funcionarioBd = new FuncionarioBd();
        private ExtraBd extraBd = new ExtraBd();
        private Funcionario funcionario;
        public Form2()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Extra horaExtra;

            int quantidadeH = Int32.Parse(txtHora.Text);
            int quantidadeMin = Int32.Parse(txtMin.Text);
            DateTime dia = escolhaDia.Value;
            string obs = txtObs.Text;
            int codFk = funcionario.Matricula;

            horaExtra = new Extra(quantidadeH, quantidadeMin, dia, obs, funcionario);

            extraBd.salvar(horaExtra);

            MessageBox.Show("Horas extras foram adicionadas !");
            txtHora.Text = "";
            txtMin.Text = "";
            txtObs.Text = "";

            defineF();

        }

        public void defineMatricula(string codigoS)
        {
            this.codigo = codigoS;
            defineF();
        }

        private void defineF()
        {
            
            int codigoI = Int32.Parse(codigo);
            funcionario = funcionarioBd.escolhido(codigoI);
            lbNome.Text = funcionario.NomeFuncionario;
            lblMatricula.Text = funcionario.Matricula.ToString();


            DataTable dt = extraBd.listar(codigoI);     

            tabelaExtra.DataSource = dt;
            tabelaExtra.Columns[0].Visible = false;
            tabelaExtra.Columns[1].HeaderText = "Horas";
            tabelaExtra.Columns[2].HeaderText = "Minutos";
            tabelaExtra.Columns[3].HeaderText = "Data";
            tabelaExtra.Columns[4].HeaderText = "Observação";
            tabelaExtra.Columns[4].Width = 190;
            tabelaExtra.Columns[5].Visible = false;


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void LbNome_Click(object sender, EventArgs e)
        {

        }

        private void TabelaExtra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
