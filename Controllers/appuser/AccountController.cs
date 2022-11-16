using System.Net;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using webapi.Data;
using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;

using AutoMapper;

namespace webapi.Controllers;

public class AccountController : BaseApiController
{

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public readonly IConfiguration _configuration;
    public readonly ILogger<AccountController> _logger;
    public readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public readonly ITokenService _tokenService;
    public readonly IUserRepository _userRepository;

    public AccountController(
        UserManager<AppUser> userManager, IConfiguration config, IMapper mapper,
        SignInManager<AppUser> signInManager, ITokenService tokenService, 
        ILogger<AccountController> logger, DataContext dataContext,
        IUserRepository userRepository
             )
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = config;
        _logger = logger;
        _tokenService = tokenService;
        _dataContext = dataContext;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    
   [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
       var user = await _userRepository.GetAppUserAsync(registerDto.Username);

       if (user != null) return BadRequest("Invalid");

        AppUser userregister = _mapper.Map<AppUser>(registerDto);


        var result = await _userManager.CreateAsync(userregister, registerDto.Password);

        if (!result.Succeeded) return BadRequest();

       // var roleResult = await _userManager.AddToRoleAsync(userregister, "Member");

     //   if (!roleResult.Succeeded) return BadRequest();

        return Ok();
        
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetAppUserAsync(loginDto.Username);

        if (user == null) return Unauthorized("Invalid username");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized();
        
        UserDto response = new UserDto();
        
        _mapper.Map(user, response);

        response.Token = _tokenService.CreateToken(user);
        response.HasPrivacyPolicyAccepted=user.HasPrivacyPolicyAccepted;

        return Ok(response);
    }
   ///
    [HttpPost("TokenGenPassword")]
    public async Task<ActionResult> TokenGenPassword(String Username) 
    {
        AppUser user = await _userRepository.GetAppUserAsync(Username);
        string resettoken = await _userManager.GeneratePasswordResetTokenAsync(user);
        if(resettoken == null) return BadRequest();
        //TODO: SEND EMAIL -- WIP
        return Ok(resettoken);


        //htttp://localhost.com/api/resetPassword2?token=sjghqkrgujhbeikugruhjbeurg&password=sdg&email=sdjg
    }
    
    [HttpPost("ResetPassword/{token}")]
    public async Task<ActionResult> ResetPassword(string token, string password, string email)
    {
        
        AppUser user = await _userRepository.GetAppUserByEmailAsync(email);
        if (user == null) return Unauthorized("Invalid email");

        IdentityResult result = await _userManager.ResetPasswordAsync(user, token, password);
        if (result.Succeeded) return Ok();
        return BadRequest();
    
                
    }
   //https://ironpython.net/tools/

    //     private void run_cmd(string cmd, string args)
    // {
    //      ProcessStartInfo start = new ProcessStartInfo();
    //      start.FileName = "my/full/path/to/python.exe";
    //      start.Arguments = string.Format("{0} {1}", cmd, args);
    //      start.UseShellExecute = false;
    //      start.RedirectStandardOutput = true;
    //      using(Process process = Process.Start(start))
    //      {
    //          using(StreamReader reader = process.StandardOutput)
    //          {
    //              string result = reader.ReadToEnd();
    //              Console.Write(result);
    //          }
    //      }
    // }
}