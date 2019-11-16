using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime CommentUpdateTime { get; set; }
        public string CommentContent { get; set; }
        public Order.State OrderState { get; set; }
        public string Size { get; set; }
        public int Amount { get; set; }
        public Order.ProductType Type { get; set; }
        public DateTime Deadline { get; set; }
        public byte[] Pattern { get; set; }
        public string OrderComment { get; set; }
        public DateTime OrderTime { get; set; }
        public string Fonts { get; set; }
        public string PatternPlace { get; set; }

    }

    //public class OrderDetailsDTO
    //{
    //    public int OrderId { get; set; }
    //    public DateTime CommentUpdateTime { get; set; }
    //    public string CommentContent { get; set; }
    //    public Order.State OrderState { get; set; }
    //    public string Size { get; set; }
    //    public int Amount { get; set; }
    //    public DateTime Deadline { get; set; }
    //    public byte[] Pattern { get; set; }
    //    public string OrderComment { get; set; }
    //    public DateTime OrderTime { get; set; }
    //    public string Fonts { get; set; }
    //    public Order.ProductType Type { get; set; }
    //    public string PatternPlace { get; set; }
    //}

    public class OrderPatchDTOUnion
    {
        public DateTime CommentUpdateTime { get; set; }
        public string CommentContent { get; set; }
        public Order.State OrderState { get; set; }
        public string Size { get; set; }
        public int Amount { get; set; }
        public DateTime Deadline { get; set; }
        public byte[] Pattern { get; set; }
        public string OrderComment { get; set; }
        public DateTime OrderTime { get; set; }
        public string Fonts { get; set; }
        public Order.ProductType Type { get; set; }
        public string PatternPlace { get; set; }


    }

    public class OrderPatchDTO
    {
        public DateTime CommentUpdateTime { get; set; }
        public string CommentContent { get; set; }
        public Order.State OrderState { get; set; }

    }

    public class OrderPatchDetailsDTO
    {
        public string Size { get; set; }
        public int Amount { get; set; }
        public DateTime Deadline { get; set; }
        public byte[] Pattern { get; set; }
        public string OrderComment { get; set; }
        public DateTime OrderTime { get; set; }
        public string Fonts { get; set; }
        public Order.ProductType Type { get; set; }
        public string PatternPlace { get; set; }
    }
}
