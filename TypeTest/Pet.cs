using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeTest
{
    internal abstract class  Pet
    {
        // 필드 선언 : 라벨, 픽쳐박스, 콤보박스, 이름, 패널

        Label _lbl;
        PictureBox _pb;
        ComboBox _cb;
        //Panel _panel;
        //string _name;

        // 프로퍼티 선언 : 패널과 캣 네임

        //public Panel Pn { get { return _pn; } }
        //public string CatName { get { return _name; } set { _name = value; } };

        public Panel Pn { get; }

        public string Name { get; set; }

        protected PictureBox Pb { get { return _pb; } set { _pb = value; } }   

        public Pet(string petName, int x, int y)
        {
            Name = petName;
            _lbl = MakeLabel();
            _lbl.Text = petName;
            _pb = MakePictureBox();
            _cb = MakeComboBox();
            Pn = MakePanel(x, y);
            Pn.Controls.Add(_lbl);
            Pn.Controls.Add(_pb);
            Pn.Controls.Add(_cb);
            Idle();
        }

        public abstract void Idle();


        public abstract void Hungry();


        public abstract void Feed();


        public abstract void Happy();


        public abstract void Cry();


        public abstract void Sleep();
        

        private Label MakeLabel()
        {
            Label Ibl = new()
            {
                Size = new Size(70, 19),
                Location = new Point(5, 5)
            };

            return Ibl;
        }

        private Panel MakePanel(int x, int y)
        {
            Panel pn = new()
            {
                Size = new Size(210, 230),
                Location = new Point(x, y)
            };

            return pn;
        }

        private PictureBox MakePictureBox()
        {
            PictureBox pb = new()
            {
                Size = new Size(200, 200),
                Location = new Point(5, 28)
            };

            return pb;
        }

        private ComboBox MakeComboBox()
        {
            string[] emotions = { "idle", "Hungry", "Feed", "Cry", "Sleep", "Happy" };

            ComboBox cb = new()
            {
                Size = new Size(121, 23),
                Location = new Point(84, 3),
                DropDownStyle = ComboBoxStyle.DropDown
            };
            cb.Items.AddRange(emotions);
            cb.SelectedIndex = 0;
            cb.SelectedIndexChanged += Cb_SelectedIndexChanged;

            return cb;
        }

        private void Cb_SelectedIndexChanged(object? sender, EventArgs e)
        {
            switch (_cb.SelectedIndex)
            {
                case 0:
                    Idle();
                    break;
                case 1:
                    Hungry();
                    break;
                case 2:
                    Feed();
                    break;
                case 3:
                    Cry();
                    break;
                case 4:
                    Sleep();
                    break;
                case 5:
                    Happy();
                    break;
            }
        }
    }
}
