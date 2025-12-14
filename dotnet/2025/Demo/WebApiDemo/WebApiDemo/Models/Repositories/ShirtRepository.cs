namespace WebApiDemo.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>(){
            new Shirt{ShirtId =1,Brand ="My Brand",Color ="Blue",Gender="Men",Price=30,Size=10},
            new Shirt {ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Men",Price=35,Size=12},
            new Shirt { ShirtId = 3, Brand = "Your Brand", Color = "pink", Gender = "Women", Price = 28, Size = 8 },
            new Shirt {ShirtId = 4, Brand = "Your Brand", Color = "Yello", Gender = "women", Price = 30, Size = 9 }
            };


        public static bool ShirtExists(int id)
        {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static List<Shirt> GetAllShirts()
        {
            return shirts;
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(s => !string.IsNullOrWhiteSpace(brand) && !string.IsNullOrWhiteSpace(s.Brand) && s.Brand == brand &&
                                              !string.IsNullOrWhiteSpace(gender) && !string.IsNullOrWhiteSpace(s.Gender) && s.Gender == gender &&
                                              !string.IsNullOrWhiteSpace(color) && !string.IsNullOrWhiteSpace(s.Color) && s.Color == color &&
                                              size.HasValue && s.Size.HasValue && s.Size.Value == size.Value);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(s => s.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var existingShirt = shirts.First(x => x.ShirtId == shirt.ShirtId);
            if (existingShirt != null)
            {
                existingShirt.Brand = shirt.Brand;
                existingShirt.Color = shirt.Color;
                existingShirt.Size = shirt.Size;
                existingShirt.Gender = shirt.Gender;
                existingShirt.Price = shirt.Price;
            }
        }

        public static void DeleteShirt(int id)
        {
            var shirtToDelete = GetShirtById(id);
            if (shirtToDelete != null)
            {
                shirts.Remove(shirtToDelete);
            }
        }
    }
}
