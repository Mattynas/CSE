
using System.Collections;

namespace WindowsFormsCSE.Model
{
    public class Item : IEnumerable 
    {
        private string Name { get; set; }
        private float price { get; set; }

        public Item(string name, float price)
        {
            this.Name = name;
            this.price = price;
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
