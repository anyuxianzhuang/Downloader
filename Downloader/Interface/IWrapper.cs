using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Interface
{
    public interface IWrapper
    {
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="task"></param>
        /// <returns>0 成功 1 可重试  2 不可重试 大于10也为可重试其含义由脚本定义</returns>
        int Download(ITask task);
        void SwitchToThisWindow();
    }
}
