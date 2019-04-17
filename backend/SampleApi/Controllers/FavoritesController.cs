using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Providers.Security;

namespace SampleApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private IFavoriteDAO favoriteDAO;
        private IUserDAO userDAO;
        private ITokenGenerator tokenGenerator;
        private IPasswordHasher passwordHasher;

        public FavoritesController(IFavoriteDAO favoriteDAO, IUserDAO userDAO, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
        {
            this.favoriteDAO = favoriteDAO;
            this.userDAO = userDAO;
            this.tokenGenerator = tokenGenerator;
            this.passwordHasher = passwordHasher;

        }

        [HttpGet("{username}")]
        public ActionResult GetFavorites([FromRoute] string username)
        {
            var user = userDAO.GetUser(username);
            if (user != null)
            {
                return Ok(favoriteDAO.GetFavoritesByUser(username));
            }

            return NotFound();
        }
    }
}