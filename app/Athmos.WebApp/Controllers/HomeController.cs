using Athmos.Application.UserServices.GetAllUsers;
using Athmos.Application.UserServices.RegisterUser;
using Athmos.Application.UserServices.UpdateUser;
using Athmos.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Athmos.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMediator mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var dto =  await this.mediator.Send(new GetAllUsersQuery());

            return View(dto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Lastname,Edad,Email")] RegisterUserCommand command)
        {
            if (ModelState.IsValid)
            {
                var dto = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Modify(string idUser)
        {
            TempData["IdUser"] = idUser;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Modify([Bind("Name,Lastname,Edad")] UpdateUserCommand command)
        {
            if (ModelState.IsValid)
            {
                command.Id = TempData["IdUser"].ToString();
                var dto = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
