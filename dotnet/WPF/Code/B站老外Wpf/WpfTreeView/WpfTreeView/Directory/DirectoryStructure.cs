using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace WpfTreeView
{
    public static class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            //加载所有的根磁盘
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// 获取绝对路径下的文件(夹)
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            #region 获取文件夹
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            #region 获取文件
            try
            {
                var fs = System.IO.Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch (Exception)
            {
                throw;
            }
            #endregion

            return items;
        }

        /// <summary>
        /// 从绝对路径获取文件夹或者文件的名字
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDirOrFileName(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return string.Empty;

            string normalPath = path.Replace("/", "\\");

            int lastIndex = normalPath.LastIndexOf('\\');

            if (lastIndex <= 0) return path;

            return path.Substring(lastIndex + 1);
        }
    }
}
