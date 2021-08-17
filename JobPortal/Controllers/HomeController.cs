using AutoMapper;
using JobPortal.Domains;
using JobPortal.Factory;
using JobPortal.Models;
using JobPortal.Services.RegisterService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminFactory _adminFactory;
        private readonly IJobSeekerFactory _jobSeekerFactory;
        private readonly IJobPosterFactory _jobPosterFactory;
        private readonly IRegisterService _registerService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,IAdminFactory adminFactory,
            IJobSeekerFactory jobSeekerFactory, IJobPosterFactory jobPosterFactory,
            IRegisterService registerService,
            IMapper mapper)
        {
            _logger = logger;
            _adminFactory = adminFactory;
            _jobSeekerFactory = jobSeekerFactory;
            _jobPosterFactory = jobPosterFactory;
            _registerService = registerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LoginAsync()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var result = await _registerService.GetRegisterByEmailAndPasswordAsync(model.Email, model.Password);
            if (result == null)
                return null;
            if (result.RoleType.ToString() == "Admin")
                return RedirectToAction("Index","Admin",new { id=result.Id});
            else if (result.RoleType.ToString() == "JobSeeker")
                return RedirectToAction("Index","JobSeeker", new { id = result.Id });
            else
                return RedirectToAction("Index","JobPoster", new { id = result.Id });
        }

        public IActionResult RegisterAsync()
        {
            var model = new RegisterModel();
            // make enum to selectListItem 
            model.AvaliableRoles = Enum.GetValues(typeof(Role)).Cast<Role>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
           model.AvaliableRoles.Insert(0,new SelectListItem { Text="Choose a role", Value="0"});

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            if (model.RoleId == 0)
                return null;
            else if (model.RoleId == 1)
            {
                var admin = await _adminFactory.PreparedRegisterAdminModelAsync(model);
                //return null;
            }
            else if (model.RoleId == 2)
            {
                var jobseeker = await _jobSeekerFactory.PrepeareRegisterJobSeekerModelAsync(model);
            }
            else
            {
                var jobPoster = await _jobPosterFactory.PreparedRegisterJobPosterAsync(model);
            }
            return View(new RegisterModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
