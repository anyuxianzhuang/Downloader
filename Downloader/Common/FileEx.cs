using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Common
{
    public class FileEx
    {
        public static void Unix2Dos(string fileName)
        {
            const byte CR = 0x0D;
            const byte LF = 0x0A;
            byte[] DOS_LINE_ENDING = new byte[] { CR, LF };
            byte[] data = File.ReadAllBytes(fileName);
            using (FileStream fileStream = File.OpenWrite(fileName))
            {
                BinaryWriter bw = new BinaryWriter(fileStream);
                int position = 0;
                int index = 0;
                do
                {
                    index = Array.IndexOf<byte>(data, LF, position);
                    if (index >= 0)
                    {
                        if ((index > 0) && (data[index - 1] == CR))
                        {
                            bw.Write(data, position, index - position + 1);
                        }
                        else
                        {
                            bw.Write(data, position, index - position);
                            bw.Write(DOS_LINE_ENDING);
                        }
                        position = index + 1;
                    }
                }
                while (index > 0);
                bw.Write(data, position, data.Length - position);
                fileStream.SetLength(fileStream.Position);
            }
        }

        public static void Dos2Unix(string fileName)
        {
            const byte CR = 0x0D;
            const byte LF = 0x0A;
            byte[] data = File.ReadAllBytes(fileName);
            using (FileStream fileStream = File.OpenWrite(fileName))
            {
                BinaryWriter bw = new BinaryWriter(fileStream);
                int position = 0;
                int index = 0;
                do
                {
                    index = Array.IndexOf<byte>(data, CR, position);
                    if ((index >= 0) && (data[index + 1] == LF))
                    {
                        bw.Write(data, position, index - position);
                        position = index + 1;
                    }
                }
                while (index > 0);
                bw.Write(data, position, data.Length - position);
                fileStream.SetLength(fileStream.Position);
            }
        }
    }
}
