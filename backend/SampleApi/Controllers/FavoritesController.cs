using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;

namespace SampleApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/{username: string}")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private IFavoriteDAO favoriteDAO;
        private IUserDAO userDAO;

        public FavoritesController(IFavoriteDAO favoriteDAO, IUserDAO userDAO) 
        {
            this.favoriteDAO = favoriteDAO;
            this.userDAO = userDAO;
        }

        [Route("/api/[controller]")]
        [HttpGet ("{username}")]
        public ActionResult GetFavorites([FromRoute] string username)
        {
            return Ok(favoriteDAO.GetFavoritesByUser(username));
        }
    }
}