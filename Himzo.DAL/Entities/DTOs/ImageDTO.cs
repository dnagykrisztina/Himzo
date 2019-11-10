using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class ImageDTO
    {
        public int ImageId { get; set; }
        public byte[] ByteImage { get; set; }
    }

    public class ImagePatchDTO
    {
        public string Path { get; set; }
        public byte[] ByteImage { get; set; }
        public Order.ProductType Type { get; set; }
        public Boolean Active { get; set; }
    }
}
