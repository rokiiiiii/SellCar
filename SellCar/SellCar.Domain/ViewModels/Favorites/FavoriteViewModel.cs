using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.Domain.ViewModels.Favorites
{
    public class FavoriteViewModel
    {
       
            public List<FavItemModel> Favs { get; set; }

      
        public class FavItemModel
        {
            public int AdsId { get; set; }
            public string PicUrl { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public double Price { get; set; }
        }
    }
}
