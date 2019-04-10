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
        //[Required]
        public string Username { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
       // [Required]
        //[MinLength(6)]
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
        //[Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        //[Required]
        public string LastName { get; set; }

        /// <summary>
        /// The user's address.
        /// </summary>
        //[Required]
        public string AddressOne { get; set; }

        /// <summary>
        /// The user's second address if applicable
        /// </summary>
        public string AddressTwo { get; set; }

        /// <summary>
        /// The user's city.
        /// </summary>
       // [Required]
        public string City { get; set; }

        /// <summary>
        /// The user's state
        /// </summary>
       // [Required]
        public string State { get; set; }

        /// <summary>
        /// The user's postal code.
        /// </summary>
        //[Required]
        public string PostalCode { get; set; }

    }
}
