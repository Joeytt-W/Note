namespace WpfTreeView
{
    public class DirectoryItem
    {
        /// <summary>
        /// 类型
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// 绝对路径
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// 文件(夹)名
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetDirOrFileName(FullPath); } }
    }
}
