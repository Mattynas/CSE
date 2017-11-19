
using System;
using System.Collections;
using System.Collections.Generic;

namespace shopGuru_android.Model
{
    public struct Item: IEquatable<Item>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool Equals(Item other)
        {
            return (Name.Equals(other.Name) && Price.Equals(other.Price));
        }
    }
}
