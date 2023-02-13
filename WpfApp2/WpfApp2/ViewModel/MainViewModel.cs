using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using WpfApp2.Models;

namespace WpfApp2.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            menuModels.Add(new MenuModel() { IconFont = "\xe635", Title = "�ҵ�һ��", BackColor = "#218868", Display = false });
            menuModels.Add(new MenuModel() { IconFont = "\xe6b6", Title = "��Ҫ", BackColor = "#EE3B3B", Display = false });
            menuModels.Add(new MenuModel() { IconFont = "\xe6e1", Title = "�Ѽƻ��ճ�", BackColor = "#218868", });
            menuModels.Add(new MenuModel() { IconFont = "\xe614", Title = "�ѷ������", BackColor = "#EE3B3B", });
            menuModels.Add(new MenuModel() { IconFont = "\xe755", Title = "����", BackColor = "#218868", });

            MenuModel = MenuModels[0];

            SelectedCommand = new RelayCommand<MenuModel>(m => Select(m));
            SelectedTaskCommand = new RelayCommand<TaskInfo>(t => SelectedTask(t));
        }

        private ObservableCollection<MenuModel> menuModels;
        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { menuModels = value; RaisePropertyChanged(); }
        }


        #region ѡ�еĲ˵�
        private MenuModel menuModel;
        public MenuModel MenuModel
        {
            get { return menuModel; }
            set { menuModel = value; RaisePropertyChanged(); }
        }
        private void Select(MenuModel model)
        {
            MenuModel = model;
        }
        #endregion


        #region ѡ�е�����
        private TaskInfo info;
        public TaskInfo Info
        {
            get { return info; }
            set { info = value; RaisePropertyChanged(); }
        }
        public void SelectedTask(TaskInfo task)
        {
            Info = task;
            Messenger.Default.Send(task, "Expand");
        }
        #endregion

        #region ���˵����������
        public void AddTaskInfo(string taskContent)
        {
            MenuModel.TaskInfos.Add(new TaskInfo() { Content = taskContent });
        }
        #endregion

        public RelayCommand<MenuModel> SelectedCommand { get; set; }

        public RelayCommand<TaskInfo> SelectedTaskCommand { get; set; }




    }
}