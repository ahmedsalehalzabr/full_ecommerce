﻿using AutoMapper;
using full_ecommerce.Data.Models;
using full_ecommerce.DTO;
using full_ecommerce.Repositories.Implementation;
using full_ecommerce.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace full_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpPost]
      //  [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressDto request)
        {
            var address = new Address
            {
                UserId = request.UserId,
                Name = request.Name,
                City = request.City,
                Street = request.Street,
                Lat = request.Lat,
                Long = request.Long,


            };



            address = await addressRepository.CreateAsync(address);

            var response = new AddressDto
            {
                Id = address.Id,
                UserId = address.UserId,
                Name = address.Name,
                City = address.City,
                Street = address.Street,
                Lat = address.Lat,
                Long = address.Long,



            };

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            var addresses = await addressRepository.GetAllAsync();

            var response = new List<AddressDto>();
            foreach (var address in addresses)
            {
                response.Add(new AddressDto
                {
                    Id = address.Id,
                    UserId = address.UserId,
                    Name = address.Name,
                    City = address.City,
                    Street = address.Street,
                    Lat = address.Lat,
                    Long = address.Long,

                });
            }

            return Ok(response);

        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetAddressById([FromRoute] Guid id)
        {
            var address = await addressRepository.GetByUserIdAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            //convert domain model to DTO
            var response = new AddressDto
            {
                Id = address.Id,
                UserId = address.UserId,
                Name = address.Name,
                City = address.City,
                Street = address.Street,
                Lat = address.Lat,
                Long = address.Long,

            };
            return Ok(response);
        }




        [HttpPut]
        [Route("{id:Guid}")]
      //  [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateBlogPostById([FromRoute] Guid id, UpdateAddressDto request)
        {
            //Convert DTO to Domain Model

            var address = new Address
            {
               
                UserId = request.UserId,
                Name = request.Name,
                City = request.City,
                Street = request.Street,
                Lat = request.Lat,
                Long = request.Long,


            };



            // call repository to update BlogPost domain model
            var updateAddress = await addressRepository.UpdateAsync(address);

            if (updateAddress == null)
            {
                return NotFound();
            }

            //convert domain model back to DTO
            var response = new AddressDto
            {
                Id = address.Id,
                UserId = address.UserId,
                Name = address.Name,
                City = address.City,
                Street = address.Street,
                Lat = address.Lat,
                Long = address.Long,

            };
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
      //  [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteAddress([FromRoute] Guid id)
        {
            var deleteAddress = await addressRepository.DeleteAsync(id);

            if (deleteAddress == null) { return NotFound(); }

            //convert Domain model to DTO
            var response = new AddressDto
            {
                Id = deleteAddress.Id,
                UserId = deleteAddress.UserId,
                Name = deleteAddress.Name,
                City = deleteAddress.City,
                Street = deleteAddress.Street,
                Lat = deleteAddress.Lat,
                Long = deleteAddress.Long,
            };
            return Ok(response);

        }
    }
}