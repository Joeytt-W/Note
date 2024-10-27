using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfTreeView
{
    public class DirectoryItemViewModel: BaseViewModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetDirOrFileName(FullPath); } }

        /// <summary>
        /// 子目录集合
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public DirectoryItemViewModel(string fullPath,DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;

            this.ClearChildren();
        }

        /// <summary>
        /// 是否可以向下展开
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value)
                    Expand();
                else
                    this.ClearChildren();
            }
        }

        public RelayCommand ExpandCommand { get; set; }


        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null); 
        }

        /// <summary>
        /// 展开文件夹
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Expand()
        {
            if(this.Type == DirectoryItemType.File)
                return;

            this.Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(this.FullPath).Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
