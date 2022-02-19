using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WpfApp4.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> OpenCommand { get; set; }

        /// <summary>
        /// IRegionManager负责管理所有定义的区域
        /// </summary>
        /// <param name="regionManager"></param>
        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            OpenCommand = new DelegateCommand<string>(Open);
        }

        private void Open(string obj)
        {
            //通过IRegionManager获取到全局定义的可用区域
            //通过依赖注入的形式往区域动态的设置内容
            _regionManager.Regions["ContentRegion"].RequestNavigate(obj);
        }
    }
}
