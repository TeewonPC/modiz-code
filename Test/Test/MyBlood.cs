﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MyBlood:INotifyPropertyChanged
    {
        private int _blood;
        public int blood
        {
            get { return _blood; }
            set
            {
                _blood = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("blood"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}