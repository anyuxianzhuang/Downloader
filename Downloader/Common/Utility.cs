using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Common
{
    public class Utility
    {
        public static List<Type> GetInterfaceSubClassType(Type type)
        {
            var subType = new List<Type>();
            var assembly = type.Assembly;
            var assemblyAllType = assembly.GetTypes();
            foreach (var iType in assemblyAllType)
            {
                if (iType.IsAbstract)
                    continue;
                var iInterface = iType.GetInterface(type.Name);
                if (iInterface != null)
                    subType.Add(iType);
            }
            return subType;
        }
    }
}
