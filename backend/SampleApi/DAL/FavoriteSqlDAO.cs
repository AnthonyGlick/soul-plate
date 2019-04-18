using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public class FavoriteSqlDAO : IFavoriteDAO
    {
        private readonly string connectionString;

        // TODO: readd address to sql statement (if we uncomment it elsewhere)
        private const string ADD_FAVORITE = "INSERT INTO favorites(user_username, restaurant_id, name, featured_image, price_range) VALUES(@userUsername, @restaurantId, @restaurantName, @restaurantImage, @restaurantPriceRange)";
        private const string DELETE_FAVORITE = "DELETE favorites WHERE user_username=@userUsername AND restaurant_id=@restaurantId";
        private const string GET_FAVORITES = "SELECT * FROM favorites WHERE user_username=@userUsername";

        public FavoriteSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void DislikeRestaurant(int restaurantId, string userUsername)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(DELETE_FAVORITE, conn);

                    cmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    cmd.Parameters.AddWithValue("@userUsername", userUsername);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public IList<Favorite> GetFavoritesByUser(string userUsername)
        {
            List<Favorite> restaurants = new List<Favorite>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(GET_FAVORITES, conn);
                    cmd.Parameters.AddWithValue("@userUsername", userUsername);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Favorite favorite = ConvertReaderToFavorite(reader);
                        restaurants.Add(favorite);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return restaurants;
        }

        private Favorite ConvertReaderToFavorite(SqlDataReader reader)
        {
            Favorite favorite = new Favorite();

            favorite.RestaurantId = Convert.ToInt32(reader["restaurant_id"]);
            favorite.UserUsername = Convert.ToString(reader["user_username"]);
            favorite.RestaurantName = Convert.ToString(reader["name"]);
            //favorite.RestaurantAddress = Convert.ToString(reader["address"]);
            favorite.RestaurantImage = Convert.ToString(reader["featured_image"]);
            favorite.RestaurantPriceRange = Convert.ToInt32(reader["price_range"]);

            return favorite;
        }

        public void LikeRestaurant(int restaurantId, string userUsername, string restaurantName, /*string restaurantAddress, */string restaurantImage, int restaurantPriceRange)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(ADD_FAVORITE, conn);

                    cmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    cmd.Parameters.AddWithValue("@userUsername", userUsername);
                    cmd.Parameters.AddWithValue("@restaurantName", restaurantName);
                    //cmd.Parameters.AddWithValue("@restaurantAddress", restaurantAddress);
                    cmd.Parameters.AddWithValue("@restaurantImage", restaurantImage);
                    cmd.Parameters.AddWithValue("@restaurantPriceRange", restaurantPriceRange);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
