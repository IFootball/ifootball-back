﻿using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.WebApi.Security;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IFootball.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginUserResponse>> Authenticate([FromBody] LoginUserRequest userRequest)
        {
            var response = await _userService.AuthenticateAsync(userRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            response.Token = _tokenService.GenerateToken(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<RegisterUserResponse>> Register([FromBody] RegisterUserRequest userRequest)
        {
            //var response = await _userService.AuthenticateAsync()

            return Ok();
        }
    }
}
