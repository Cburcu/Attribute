using System;

namespace HwAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IdentityAttribute: Attribute
    {
        public bool IsId { get; set; }
    }
}
