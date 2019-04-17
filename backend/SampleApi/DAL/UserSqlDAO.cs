using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

namespace SampleApi.DAL
{
    /// <summary>
    /// A SQL Dao for user objects.
    /// </summary>
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public UserSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password, salt, role) VALUES (@username, @password, @salt, @role);", conn);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the user from the database.
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", user.Id);                    

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the user from the database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            User user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE username = @username;", conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }

                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Updates the user in the database.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET password = @password, salt = @salt, role = @role WHERE id = @id;", conn);                    
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@id", user.Id);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private User MapRowToUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = Convert.ToInt32(reader["id"]),
                Username = Convert.ToString(reader["username"]),
                Password = Convert.ToString(reader["password"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["role"]),
                FirstName = Convert.ToString(reader["firstname"]),
                LastName = Convert.ToString(reader["lastname"]),
                AddressOne = Convert.ToString(reader["address1"]),
                AddressTwo = Convert.ToString(reader["address2"]),
                City = Convert.ToString(reader["city"]),
                State = Convert.ToString(reader["state"]),
                PostalCode = Convert.ToString(reader["postalcode"])

                

            };
        }

        /// <summary>
        /// Method to update a users profile given a certain id
        /// </summary>
        /// <param name="user"></param>
        public void UpdateProfile(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET firstname = @firstname, lastname = @lastname, address1 = @address1, address2 = @address2, city = @city, state = @state, postalcode = @postalcode WHERE username = @username;", conn);
                    cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", user.LastName);
                    cmd.Parameters.AddWithValue("@address1", user.AddressOne);
                    //cmd.Parameters.AddWithValue("@address1", user.AddressTwo);
                    if (!String.IsNullOrEmpty(user.AddressTwo))
                    {
                        cmd.Parameters.AddWithValue("@address2", user.AddressTwo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address2", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@city", user.City);
                    cmd.Parameters.AddWithValue("@state", user.State);
                    cmd.Parameters.AddWithValue("@postalcode", user.PostalCode);
                    cmd.Parameters.AddWithValue("@username", user.Username);
              
                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// Takes in a users choice and add to favorites
        ///// </summary>
        ///// <param name="user"></param>
        //public void UpdateFavorites(User user)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand("UPDATE users SET fav01 = @favOne, fav02 = @favTwo, fav03 = @favThree, fav04= @favFour, fav05 = @favFive, fav06 = @favSix, fav07=@favSeven, fav08 = @favEight, fav09 = @favNine, fav10 = @favTen;", conn);
        //            cmd.Parameters.AddWithValue("@favOne", user.FavOne);
        //            cmd.Parameters.AddWithValue("@favTwo", user.FavTwo);
        //            cmd.Parameters.AddWithValue("@favThree", user.FavThree);
        //            cmd.Parameters.AddWithValue("@favFour", user.FavFour);
        //            cmd.Parameters.AddWithValue("@favFive", user.FavFive);
        //            cmd.Parameters.AddWithValue("@favSix", user.FavSix);
        //            cmd.Parameters.AddWithValue("@favSeven", user.FavSeven);
        //            cmd.Parameters.AddWithValue("@favEight", user.FavEight);
        //            cmd.Parameters.AddWithValue("@favNine", user.FavNine);
        //            cmd.Parameters.AddWithValue("@favTen", user.FavTen);


        //            cmd.ExecuteNonQuery();

        //            return;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }

        //}

        //public void DeleteFavorite()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("DE", conn);
        //                cmd.Parameters.AddWithValue();
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch (SqlException exception)
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;    
        //    }
        //}

    }
}
