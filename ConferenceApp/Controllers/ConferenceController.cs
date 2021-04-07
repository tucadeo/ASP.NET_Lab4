using System;
using System.Collections.Generic;
using System.IO;
using ConferenceApp.Models;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ConferenceApp.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IHostEnvironment _env;
        private static readonly List<ConferenceUserViewModel> ConferenceUsers = new();

        public ConferenceController(IHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View(ConferenceUsers);
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(
            ErrorMessage = "Prosze podać prawidłowy numer",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]
        public ActionResult Register(RegisterConferenceUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Photo is not null)
                {
                    string uploadsFolder = Path.Combine(_env.ContentRootPath, "wwwroot/images");
                    uniqueFileName = $"{Guid.NewGuid()}_{model.Photo.FileName}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    model.Photo.CopyTo(fileStream);
                }

                var conferenceUserVm = new ConferenceUserViewModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    ConferenceType = model.ConferenceType,
                    PhotoUrl = model.Photo is not null ? $"~/images/{uniqueFileName}" : "",
                };

                ConferenceUsers.Add(conferenceUserVm);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}