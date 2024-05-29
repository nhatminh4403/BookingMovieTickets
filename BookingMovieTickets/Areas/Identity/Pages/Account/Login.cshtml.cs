// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using BookingMovieTickets.Models;
using BookingMovieTickets.DataAccess;
using Azure.Core;
using BookingMovieTickets.Query;
using System.Diagnostics;

namespace BookingMovieTickets.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<UserInfo> _userManager;


        private readonly I_FilmCategoryRepository _filmCategoryRepository;
        private readonly I_FilmRepository _filmRepository;
        private readonly I_Seat _seatRepo;
        private readonly BookingMovieTicketsDBContext _dbContext;
        private readonly I_Schedule _scheduleRepo;
        private readonly I_TheatreRoom _theatreRoomRepo;
        private readonly I_Theater _TheaterRepo;
        public LoginModel(SignInManager<UserInfo> signInManager, ILogger<LoginModel> logger, UserManager<UserInfo> userManager, I_FilmCategoryRepository filmCategoryRepository,
         I_FilmRepository filmRepository, I_Seat searRepo,BookingMovieTicketsDBContext dBContext,I_Schedule scheduleRepo, I_TheatreRoom theatreRoomRepo, I_Theater theaterRepo)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _filmRepository = filmRepository;
            _seatRepo = searRepo;
            _filmCategoryRepository = filmCategoryRepository;
            _scheduleRepo = scheduleRepo;
            _theatreRoomRepo = theatreRoomRepo;
            _TheaterRepo = theaterRepo;

            _dbContext = dBContext;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// 
        public FilmVM FilmVM { get; set; }
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null, string access_token = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;

            var films = await _filmRepository.GetAllAsync();
            var categories = await _filmCategoryRepository.GetAllAsync();
            var seats = await _seatRepo.GetAllSeatAsync();
            var schedules = await _scheduleRepo.GetAllAsync();
            var rooms = await _theatreRoomRepo.GetAllRoomAsync();
            var theaters = await _TheaterRepo.GetAllAsync();
            FilmVM = new FilmVM
            {
                Films = films,
                FilmCategories = categories,
                Seats = seats,
                FilmSchedules = schedules,
                TheatreRooms = rooms,
                Theatres = theaters
            }; ViewData["LayoutViewModel"] = FilmVM;

            if (!string.IsNullOrEmpty(access_token))
            {
                TokenGoogle data = await DataQuery.VerifyTokenGoogle(access_token);
                if (data.error_description == null)
                {
                    var user = await _userManager.FindByEmailAsync(data.email);
                    if (user == null)
                    {
                        // tạo tài khoản.
                        var result = await _userManager.CreateAsync(new UserInfo { UserName = data.email, Email = data.email, FullName = data.email, PhoneNumber = data.email });
                        Debug.WriteLine("create user: " + result.Succeeded);
                        Debug.WriteLine("create user log: " + result.Errors.FirstOrDefault()?.Description);
                        if (result.Succeeded)
                            user = await _userManager.FindByEmailAsync(data.email);
                    }

                    // tạo sesion cho user.
                    if (user != null)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return LocalRedirect(returnUrl);
                    }
                }
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(Input.Email);
                    if (user != null && await _userManager.IsInRoleAsync(user, "Admin") && User.Identity.IsAuthenticated)
                    {
                        // If the user is an admin, redirect to the Manager view
                        return RedirectToAction("Index", "Manager", new { area = "Admin" });
                    }
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            var films = await _filmRepository.GetAllAsync();
            var categories = await _filmCategoryRepository.GetAllAsync();
            var seats = await _seatRepo.GetAllSeatAsync();
            var schedules = await _scheduleRepo.GetAllAsync();
            var rooms = await _theatreRoomRepo.GetAllRoomAsync();
            var theaters = await _TheaterRepo.GetAllAsync();
            FilmVM = new FilmVM
            {
                Films = films,
                FilmCategories = categories,
                Seats = seats,
                FilmSchedules = schedules,
                TheatreRooms = rooms,
                Theatres = theaters
            }; ViewData["LayoutViewModel"] = FilmVM;

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
