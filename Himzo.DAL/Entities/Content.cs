﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string ContentString { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
