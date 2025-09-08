using System;
using System.Configuration;
using System.Linq.Expressions;
using System.Security.Cryptography.Pkcs;
using System.Windows.Forms;

namespace TypeTest
{
    internal class Cat : Pet
    {
        public Cat(string petName, int x, int y) : base(petName, x, y)
        {
        }

        public override void Idle()
        {
            Pb.Image = Image.FromFile("./Images/cat_idle.gif");
        }

        public override void Hungry()
        {
            Pb.Image = Image.FromFile("./Images/cat_hungry.gif");
        }

        public override void Feed()
        {
            Pb.Image = Image.FromFile("./Images/cat_feed.gif");
        }

        public override void Happy()
        {
            Pb.Image = Image.FromFile("./Images/cat_happy.gif");
        }

        public override void Cry()
        {
            Pb.Image = Image.FromFile("./Images/cat_cry.gif");
        }

        public override void Sleep()
        {
            Pb.Image = Image.FromFile("./Images/cat_sleep.gif");
        }
    }
}
