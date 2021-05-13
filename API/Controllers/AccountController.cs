using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, 
            IMapper mapper,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDetailsDTO>> GetCurrentUser(){
            
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);
            
            return new UserDetailsDTO{
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DisplayName = user.DispayName
            };
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> GetEmailAsync([FromQuery] string email)
        {
           return await _userManager.FindByEmailAsync(email) != null;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO){
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if(!result.Succeeded){
                return Unauthorized(new ApiResponse(401));
            }
            
            return new UserDTO{
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DispayName
            };
        }

         [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegistrationDTO registerDTO)
        {
            var user = new AppUser{
                DispayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if(!result.Succeeded){
                return BadRequest(new ApiResponse(400));
            }

            return new UserDTO{
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DispayName
            };
        }
        
    }
}