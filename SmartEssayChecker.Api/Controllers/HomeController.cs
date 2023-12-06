//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace SmartEssayChecker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello Mario, the princess is in another castle.");
    }
}
