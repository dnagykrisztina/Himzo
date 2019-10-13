using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class Order
    {
        public enum State
        {
            WAITING_FOR_ANSWER,
            IN_PROGRESS,
            DENIED,
            DONE
        }
        public enum ProductType
        {
            FOLT, PULCSI, MINTA
        }
        public int OrderId { get; set; }
        public Comment Comment { get; set; }
        public State OrderState { get; set; }
        public string Size { get; set; }
        public int Amount { get; set; }
        public DateTime Deadline { get; set; }
        public byte[] Pattern { get; set; }
        public string OrderComment { get; set; }
        public DateTime OrderTime { get; set; }
        public string Fonts { get; set; }
        public ProductType Type { get; set; }
        public string PatternPlace { get; set; }
        public User User { get; set; }
    }
}
