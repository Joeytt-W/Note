using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToDo.Common.Models;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Regions;

namespace MyToDo.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenu();
            NavigateCommand = new DelegateCommand<MenuBar>();
        }

        private void Navigate(MenuBar obj)
        {

        }

        private ObservableCollection<MenuBar> menuBars;
        public ObservableCollection<MenuBar> MenuBars
        {
            get => menuBars;
            set
            {
                menuBars = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        void CreateMenu()
        {
            MenuBars.Add(new MenuBar(){Icon = "Home",Title = "首页",NameSpace = "IndexView"});
            MenuBars.Add(new MenuBar(){Icon = "NotebookOutline",Title = "待办事项",NameSpace = "ToDoView"});
            MenuBars.Add(new MenuBar(){Icon = "NotebookPlus",Title = "备忘录",NameSpace = "MemoView"});
            MenuBars.Add(new MenuBar(){Icon = "Cog",Title = "设置",NameSpace = "SettingsView"});
        }
    }
}
