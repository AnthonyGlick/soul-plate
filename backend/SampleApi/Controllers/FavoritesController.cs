using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers
{
    [Authorize]
    // TODO correct route
    //[Route("api/Home/{userId:int}/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        //private IFavoriteDAO favoriteDAO;
        //public FavoritesController(IFavoriteDAO favoriteDAO, IUserDAO userDao) : base(userDao)
        //{
        //    this.favoriteDAO = favoriteDAO;
        //}

        //[Route("/api/[controller]")]
        //[HttpGet]
        //public ActionResult GetFavorites()
        //{
        //    return Ok(favoriteDAO.GetFavoritesByUserId(CurrentUser.Id));
        //}
    }
}