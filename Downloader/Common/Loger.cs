using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Common
{
    public class Loger
    {
        private static readonly log4net.ILog LogInfo = log4net.LogManager.GetLogger("info");
        public static void Info(object msg)
        {
            MessageAcceptanceHandler?.Invoke(msg);
            LogInfo.Info(msg);
        }
        public static void Debug(object msg)
        {
            LogInfo.Info(msg);
            if (showDebugInfo)
                MessageAcceptanceHandler?.Invoke(msg);
        }
        public static bool showDebugInfo { get; set; } = true;
        public delegate void MessageAcceptanceDelegate(object msg);
        public static MessageAcceptanceDelegate MessageAcceptanceHandler;

    }
}
