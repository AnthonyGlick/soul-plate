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

        private const string ADD_FAVORITE = "INSERT INTO favorites(user_username, restaurant_id, name) VALUES(@userUsername, @restaurantId, @restaurantName)";
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

            return favorite;
        }

        public void LikeRestaurant(int restaurantId, string userUsername, string restaurantName)
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
