using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Enum
{
    /// <summary>
    /// 菜单类别
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 根目录
        /// </summary>
        Root = 1,
        
        /// <summary>
        /// 根目录下一级菜单
        /// </summary>
        LevelOne = 2,

        /// <summary>
        /// 根目录下二级菜单
        /// </summary>
        LevelTwo = 3,

        /// <summary>
        /// 根目录下三级菜单
        /// </summary>
        LevelThree = 4,

        /// <summary>
        /// 根目录下四级菜单
        /// </summary>
        LevelFour = 5,
    }
}
