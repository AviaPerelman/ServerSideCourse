namespace HomeWork2.BL
{
    public class Flat
    {
        int id;
        string city;
        string address;
        double price;
        int numbers_of_rooms;

        public static List<Flat> FlatsList = new List<Flat>();

        public Flat()
        {

        }
        public Flat(int id, string city, string address, double price, int numbers_of_rooms)
        {
            Id = id;
            City = city;
            Address = address;
            Price = price;
            Numbers_of_rooms = numbers_of_rooms;
        }

        public int Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public int Numbers_of_rooms { get => numbers_of_rooms; set => numbers_of_rooms = value; }
        public double Price {get => price; set => price = value; }
        

        public bool Insert()
        {
            foreach (var item in FlatsList)
            {
                if (item.id == this.id)
                {
                    return false;
                }
            }

            if(this.numbers_of_rooms > 1 && this.price > 100 )
            this.price *= 0.9;

            FlatsList.Add(this);
            return true;
        }

      

        public List<Flat> Read() => FlatsList;

        //public double Discount(double price)
        //{
        //    if (numbers_of_rooms > 1 && price > 100)
        //    {
        //        price *= 0.9;
        //    }

        //    return price;

        //}

        public List<Flat> ReadByPriceAndCity(string city, double maxPrice)
        {
            List<Flat> selectedList = new List<Flat>();

            foreach (var item in FlatsList)
            {
                if (item.city == city && item.price <= maxPrice) selectedList.Add(item);
            }
            return selectedList;
        }
    }
}
