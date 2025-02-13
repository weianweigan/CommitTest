﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;


namespace WpfApp2.Models
{
    public class MenuModel : ViewModelBase

    {

        public string IconFont { get; set; }

        public string Title { get; set; }

        public string BackColor { get; set; }

        public bool Display { get; set; } = true;

        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }

            set
            {
                taskInfos = value;
                RaisePropertyChanged();
            }

        }
    }

    public class TaskInfo
    {
        public string Content { get; set; }
    }
}
