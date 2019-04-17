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

        private const string ADD_FAVORITE = "INSERT INTO favorites(user_username, restaurant_id) VALUES(@userUsername, @restaurantId)";
        private const string DELETE_FAVORITE = "DELETE favorites WHERE user_username=@userUsername AND restaurant_id=@restaurantId";
        private const string GET_FAVORITES = "SELECT restaurant_id FROM favorites WHERE user_username=@userUsername";

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

        public IList<int> GetFavoritesByUser(string userUsername)
        {
            List<int> restaurants = new List<int>();

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
                        int restaurantId = Convert.ToInt32(reader["restaurant_id"]);
                        restaurants.Add(restaurantId);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return restaurants;
        }

        public void LikeRestaurant(int restaurantId, string userUsername)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(ADD_FAVORITE, conn);

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
    }
}
