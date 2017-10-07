
namespace WindowsFormsCSE.Model
{
    public struct Item
    {
        private string Name { get; set; }
        private float price { get; set; }

        public Item(string name, float price)
        {
            this.Name = name;
            this.price = price;
        }

    }
}
