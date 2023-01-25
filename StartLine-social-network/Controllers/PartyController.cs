﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartLine_social_network.Data;
using StartLine_social_network.Data.Interfaces;
using StartLine_social_network.Models;
using StartLine_social_network.ViewModels;

namespace StartLine_social_network.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyService _partyService;
        private readonly IPhotoService _photoService;

        public PartyController(IPartyService partyService, IPhotoService photoService)
        {
            _partyService = partyService;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Party> party = await _partyService.GetAllElements();
            return View(party);
        }
        // Detail page for single element
        public async Task<IActionResult> Detail(int id)
        {
            // We use Include() to make join between Address.cs
            Party party = await _partyService.GetByIdAsync(id);
            return View(party);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePartyViewModel partyVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(partyVM.Image);

                var party = new Party
                {
                    Title = partyVM.Title,
                    Description = partyVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = partyVM.Address.Street,
                        City = partyVM.Address.City,
                        Province = partyVM.Address.Province,
                    }
                };
                _partyService.Add(party);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(partyVM);
        }
        // Passing data to the model
        public async Task<IActionResult> Edit(int id)
        {
            var party = await _partyService.GetByIdAsync(id);
            if (party == null) return View("Error");

            var partyVM = new EditPartyViewModel
            {
                Title = party.Title,
                Description = party.Description,
                AddressId = (int)party.AddressId,
                Address = party.Address,
                URL = party.Image,
                PartyClubCategory = party.PartyClubCategory
            };
            return View(partyVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubViewModel partyVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit");
                return View("Edit", partyVM);
            }
            var userParty = await _partyService.GetByIdAsyncNoTracking(id);

            if (userParty != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userParty.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete the photo");
                    return View(partyVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(partyVM.Image);

                var party = new Party
                {
                    Id = id,
                    Title = partyVM.Title,
                    Description = partyVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = partyVM.AddressId,
                    Address = partyVM.Address,
                };

                _partyService.Update(party);

                return RedirectToAction("Index");
            }
            else
            {
                return View(partyVM);
            }
        }
    }
}
