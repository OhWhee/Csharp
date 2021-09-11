using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class CodecFactory
    {
        string codec;
        int bitrate = 128;
        public CodecFactory() { }
        public CodecFactory(string codec) { this.codec = codec; }

        public int Bitrate { get => bitrate; set => bitrate = value; }

        public CodecFactory extract(VideoFile file)
        {
            string[] codec = file.Filename.Split('.');
            return new CodecFactory(codec[1]);
        }
    }
}
