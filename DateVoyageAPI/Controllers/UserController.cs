using AutoMapper;
using DateVoyage.Data;
using DateVoyage.DTOs;
using DateVoyage.Entity;
using DateVoyage.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DateVoyage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

      //  [AllowAnonymous]
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users= await _repo.GetUsersAsync();

            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> Get(string username)
        {
            var user = await _repo.GetUserByUsernameAsync(username);

            return _mapper.Map<MemberDto>(user);
        }
    }
}
