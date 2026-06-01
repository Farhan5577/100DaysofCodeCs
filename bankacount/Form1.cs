namespace bankacount
{
    public partial class Form1 : Form
    {
        List<AkunBank> akunBanks = new List<AkunBank>();
        public Form1()
        {
            InitializeComponent();

            /*AkunBank akunBank = new AkunBank("farhan");

            List<AkunBank> akunBanks = new List<AkunBank>();
            akunBanks.Add(akunBank);


            dataGridView1.DataSource = akunBanks;*/

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            AkunBank akunBank = new AkunBank(textBox1.Text);
            akunBanks.Add(akunBank);

            Tambah();
            textBox1.Text = string.Empty;
        }

        public void Tambah()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = akunBanks;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && numericUpDown1.Value > 0)
            {
                AkunBank GridSelect = dataGridView1.SelectedRows[0].DataBoundItem as AkunBank;

                GridSelect.Saldo += numericUpDown1.Value;

                Tambah();
                numericUpDown1.Value = 0;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1 && numericUpDown1.Value > 0)
            {
                AkunBank GridSelect = dataGridView1.SelectedRows[0].DataBoundItem as AkunBank ;

                GridSelect.Saldo -= numericUpDown1.Value;

                Tambah();
                numericUpDown1.Value = 0;
            }
        }
    }
}
