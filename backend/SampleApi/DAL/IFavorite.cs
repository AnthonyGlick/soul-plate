using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IFavorite
    {
        void LikeRestaurant(int restaurantId, int userId);

        void DislikeRestaurant(int restaurantId, int userId);

        //IList<Restaurant> GetFavoritesByUser(int userId);
    }
}
