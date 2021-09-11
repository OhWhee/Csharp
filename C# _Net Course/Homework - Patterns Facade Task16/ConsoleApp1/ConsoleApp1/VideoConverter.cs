using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class VideoConverter
    {
        public VideoFile convert(string filename, string format)
        {
            
            VideoFile file = new VideoFile(filename);
            CodecFactory sourceCodec = new CodecFactory().extract(file);
            if (format == "mp4")
            {
                MPEG4CompressionCodec destinationCodec = new MPEG4CompressionCodec();
            }
            else
            {
                OggCompressionCodec destinationCodec = new OggCompressionCodec();
            }
            



            return new VideoFile(result);
        }
    }
}
