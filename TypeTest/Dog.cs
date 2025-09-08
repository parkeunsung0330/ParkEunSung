using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeTest
{
    internal class Dog : Pet
    {
        public Dog(string petName, int x, int y) : base(petName, x, y)
        {
        }

        public override void Idle()
        {
            Pb.Image = Image.FromFile("./Images/dog_idle.gif");
        }

        public override void Hungry()
        {
            Pb.Image = Image.FromFile("./Images/dog_hungry.gif");
        }

        public override void Feed()
        {
            Pb.Image = Image.FromFile("./Images/dog_feed.gif");
        }

        public override void Happy()
        {
            Pb.Image = Image.FromFile("./Images/dog_happy.gif");
        }

        public override void Cry()
        {
            Pb.Image = Image.FromFile("./Images/dog_cry.gif");
        }

        public override void Sleep()
        {
            Pb.Image = Image.FromFile("./Images/dog_sleep.gif");
        }
    }
}
