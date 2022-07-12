using Data.Repositories.Interfaces;
using Data.UnitofWork.Interfaces;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mongodb.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _uow;

        public UsersController(IUsersRepository usersRepository, IUnitOfWork uow)
        {
            _usersRepository = usersRepository;
            _uow = uow;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            var users = await _usersRepository.GetAll();
            users = users.Where((item) => item.IsActive != false);
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(string id)
        {
            var user = await _usersRepository.GetById(id);

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]  
        public ActionResult Post(Users objuser)
        {
            objuser.IsActive = true;
            _usersRepository.Add(objuser);
            return Ok("200");
        }

       
        [HttpPost("Update")]
        public ActionResult Put(Users objuser)
        {
            var objrequest = new Users();
            objrequest = objuser;
          
            _usersRepository.UpdateUsers(objrequest);
            return Ok("200");
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete(Users objuser)
        {
            var objrequest = new Users();
            objrequest = objuser;
            objrequest.IsActive = false;
            _usersRepository.UpdateUsers(objrequest);
            return Ok("200");
        }

    }
}
