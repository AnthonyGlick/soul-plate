using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IFavoriteDAO
    {
        void LikeRestaurant(int restaurantId, string userUsername, string restaurantName,/* string restaurantAddress,*/ string restaurantImage, int restaurantPriceRange);

        void DislikeRestaurant(int restaurantId, string userUsername);

        // TODO create model Restaurant or Favorite for list?
        IList<Favorite> GetFavoritesByUser(string userUsername);
    }
}
