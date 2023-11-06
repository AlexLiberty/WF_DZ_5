using WF_DZ_5.Models;

namespace WF_DZ_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool[] Modifiers() => new bool[5]
        {
            checkBox1.Checked,
            checkBox2.Checked,
            checkBox3.Checked,
            checkBox4.Checked,
            checkBox5.Checked,
        };
        bool IsCheckNoRepetitions()
        {
            if (checkBox5.Checked)
            {
                bool[] options = Modifiers();
                int number = 0;
                if (options[0]) { number += 10; }
                if (options[1]) { number += 26; }
                if (options[2]) { number += 26; }
                if (options[3]) { number += 15; }
                int lenght = (int)numericUpDown1.Value;
                return lenght > number;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Length = (int)numericUpDown1.Value;
            if (Length > 0)
            {
                if (!Array.TrueForAll(Modifiers(), e => e == false))
                {
                    if (IsCheckNoRepetitions())
                    {
                        listBox1.Items.Clear();
                        Generator generator = new Generator(Length, Modifiers());
                        
                            for (int i = 0; i < 20; i++)
                        {
                            listBox1.Items.Add(generator.Generate());
                        }                    

                    }
                }

                else
                {
                    MessageBox.Show("Неможливо згенерувати пароль з унікальних символів");
                }
            }

            else
            {
                MessageBox.Show("Довжина пароля не може бути менше 1!");
            }
        }
     
    }
}