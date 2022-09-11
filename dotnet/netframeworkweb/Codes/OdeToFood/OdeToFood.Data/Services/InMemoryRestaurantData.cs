using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData:IRestaurantData
    {
        private readonly List<Restaurant> _list = new List<Restaurant>();

        public InMemoryRestaurantData()
        {
            _list.Add(new Restaurant()
            {
                Id = 1,
                Name = "Italian Food",
                Cuisine = CuisineType.Italian
            });
            _list.Add(new Restaurant()
            {
                Id = 2,
                Name = "Indian Food",
                Cuisine = CuisineType.Indian
            });
            _list.Add(new Restaurant()
            {
                Id = 3,
                Name = "French Food",
                Cuisine = CuisineType.French
            });
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _list.OrderBy(c => c.Name);
        }
    }
}
