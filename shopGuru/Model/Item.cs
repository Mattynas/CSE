
using System;
using System.Collections;

namespace shopGuru.Model
{
    public struct Item: IEquatable<Item>
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public bool Equals(Item other)
        {
            return (Name.Equals(other.Name) && Price.Equals(other.Price));
        }
    }
}
