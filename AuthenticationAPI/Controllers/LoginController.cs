﻿using System.Security.Claims;
using System.Threading.Tasks;
using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AuthenticationAPI.Controllers
{
    [ApiController]
    [Route("V1")]
    public class LoginController : ControllerBase
    { 
            [HttpPost]
            [Route("login")]
            [AllowAnonymous]
            public async Task<ActionResult<dynamic>> Authenticate(User model)
            {

               var user = LoginRepository.Get(model.UserName, model.Password);

                if (user == null)
                    return NotFound(new { message = "User or password invalidade!!" });

                var token = ServiceToken.GenerateToken(user);

                user.Password = "";

                return new
                {
                    user = user,
                    token = token
                };
            }


            [HttpGet]
            [Route("anonymous")]
            [AllowAnonymous]
            public string Anonymous() => "Anônimo";


            [HttpGet]
            [Route("authenticated")]
            [Authorize]
            public string Authenticated() => string.Format($"Autenticado - {User.Identity.Name}");



            [HttpGet]
            [Route("employee")]
            [Authorize(Roles = "employee,manager")]
            public string Employee() => "Funcionario";

            [HttpGet]
            [Route("manager")]
            [Authorize(Roles = "manager")]
            public string Manager() => "Gerente";

        public static Task Authenticate(ClaimsPrincipal user)
        {
            throw new System.NotImplementedException();
        }
    }
    }

