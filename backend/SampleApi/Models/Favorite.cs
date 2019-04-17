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
    }
}
