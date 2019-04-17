using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IFavoriteDAO
    {
        void LikeRestaurant(int restaurantId, string userUsername);

        void DislikeRestaurant(int restaurantId, string userUsername);

        // TODO create model Restaurant or Favorite for list?
        IList<int> GetFavoritesByUser(string userUsername);
    }
}
