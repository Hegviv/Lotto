namespace lotto
{
    public partial class Form1 : Form
    {
        List<Sorsolas> sorsolasok = new List<Sorsolas>();
        List<Szam> szamok = new List<Szam>();
        public Form1()
        {
            InitializeComponent();
            
            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5]);
                sorsolasok.Add(sorsolas_object);
            }

            //2.feladat
            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in sorsolasok)
                {
                    if(i == item.szam1 ||i == item.szam2 ||i == item.szam3 || i == item.szam4 || i == item.szam5)
                    {
                        db++;
                    }
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db=0;
            }
            int max_db = 0;
            int max_szam = 0;
            foreach (var item in szamok)
            {
                if(item.db > max_db)
                {
                    max_db =item.db;
                    max_szam = item.szam;
                }
            }
            label2.Text = $"legtöbbször kihúzva: { max_szam},ennyi alkalommal:{max_db}";
            foreach (var item in szamok)
                dataGridView1.Rows.Add(item.szam, item.db);
            // feladat 3
            foreach (var item in szamok)
            {
                if (item.szam %2 == 0  )
                {
                    label3.Text =$"páros: {item.db}db";
                }
            }
            // feladat 4
            foreach (var item in szamok)
            {
                if (item.szam ==4 )
                {
                    label4.Text =$"4: {item.db}db";
                }
            }
            foreach (var item in szamok)
            {
                if (item.szam ==73 )
                {
                    label5.Text =$"73: {item.db}db";
                }
            }
            foreach (var item in sorsolasok)
            {
                Console.WriteLine($"{item.het} {item.szam1} {item.szam2} {item.szam3} {item.szam4} {item.szam5}");
            }
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var item in sorsolasok)
            {
                if (numericUpDown1.Value == item.het)
                    label1.Text =$"Feladat1: {item.het}. hét: {item.szam1}, {item.szam2}, {item.szam3}, {item.szam4}, {item.szam5}";
            }
        }
    }
}