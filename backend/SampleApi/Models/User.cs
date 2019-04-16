using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user's id.
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>   
        public string Username { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The user's salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// The user's role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's address.
        /// </summary>
        public string AddressOne { get; set; }

        /// <summary>
        /// The user's second address if applicable
        /// </summary>
        public string AddressTwo { get; set; }

        /// <summary>
        /// The user's city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The user's state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The user's postal code.
        /// </summary>
        public string PostalCode { get; set; }

        public string FavOne { get; set; }
        public string FavTwo { get; set; }
        public string FavThree { get; set; }
        public string FavFour { get; set; }
        public string FavFive { get; set; }
        public string FavSix { get; set; }
        public string FavSeven { get; set; }
        public string FavEight { get; set; }
        public string FavNine { get; set; }
        public string FavTen { get; set; }

    }
}
