using System.ComponentModel;

namespace TypeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Cat nero = new Cat("네로", "Black");
            //nero.SetName("메로");
            //string str = $"고양이 이름 : {nero.GetName()},색상 : {nero.Color}";
            //MessageBox.Show(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pet[] pets = new Pet[20];
            int x = 3;
            int y = 3;
            int cols = 5;
            int rows = 0;

            for(int i = 0; i < pets.Length;i++)
            {
                if(i != 0)
                {
                    int j = i % cols;
                    if (j == 0) rows++;
                    x = 3 + 210 * j;
                    y = 3 + 230 * rows;
                }

                if(i%2 ==0)
                {
                    string name = string.Concat("Cat", (i + 1).ToString());
                    pets[i] = new Cat(name, x, y);
                }

                else
                {
                    string name = string.Concat("Dog", (i + 1).ToString());
                    pets[i] = new Dog(name, x, y);
                }

                this.Controls.Add(pets[i].Pn);
            }




            //Pet[] pets = new Pet[3];
            //pets[0] = new Cat("고양이1번", 10, 10);
            //pets[1] = new Cat("고양이2번", 230, 10);
            //pets[2] = new Dog("강아지1번", 450, 10);

            //foreach (Pet pet in pets)
            //{

            //    this.Controls.Add(pet.Pn);

            //}


            //Cat cat1 = new Cat("고양이1번", 10, 10);
            //Cat cat2 = new Cat("고양이2번", 230, 10);
            //Cat cat3 = new Cat("고양이3번", 10, 250);
            //Dog dog1 = new Dog("강아지1번", 450, 10);

            //this.Controls.Add(cat1.Pn);
            //this.Controls.Add(cat2.Pn);
            //this.Controls.Add(cat3.Pn);
            //this.Controls.Add(dog1.Pn);

            //string[] catStrArr = { "idle", "Hungry", "Feed", "Cry", "Slepp", "Happy" };
            //comboBox1.Items.AddRange(catStrArr);
            //comboBox1.SelectedIndex = 0;
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (comboBox1.SelectedIndex)
        //    {
        //        case 0:
        //            pictureBox1.Image = Image.FromFile("./Images/cat_idle.gif");
        //            break;
        //        case 1:
        //            pictureBox1.Image = Image.FromFile("./Images/cat_hungry.gif");
        //            break;
        //        case 2:
        //            pictureBox1.Image = Image.FromFile("./Images/cat_feed.gif");
        //            break;
        //        case 3:
        //            pictureBox1.Image = Image.FromFile("./Images/cat_cry.gif");
        //            break;
        //        case 4:
        //            pictureBox1.Image = Image.FromFile("./Images/cat_sleep.gif");
        //            break;
        //        case 5:
        //            pictureBox1.Image = Image.FromFile("./Images/cat_happy.gif");
        //            break;


        //    }
        //}
    }
}
