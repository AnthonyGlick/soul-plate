using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Favorite
    {
        /// <summary>
        /// User's ID
        /// </summary>
        public string UserUsername { get; set; }

        /// <summary>
        /// ID of favorited restaurant
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Name of favorited restaurant
        /// </summary>
        public string RestaurantName { get; set; }

        ///// <summary>
        ///// Address of favorited restaurant (number, street, city, state)
        ///// </summary>
        //public string RestaurantAddress { get; set; }

        ///// <summary>
        ///// Image URL of favorited restaurant
        ///// </summary>
        //public string RestaurantImage { get; set; }

        ///// <summary>
        ///// Price range (integer 1-4) of favorited restaurant
        ///// </summary>
        //public int RestaurantPriceRange { get; set; }
    }
}
