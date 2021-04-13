﻿using DeliverIt.Data;
using DeliverIt.Data.Models;
using DeliverIt.Services.Contracts;
using DeliverIt.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverIt.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly DeliverItContext dbcontext;

        public AddressService(DeliverItContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public AddressDTO Create(Address address)
        {
            this.dbcontext.Addresses.Add(address);
            address.CreatedOn = DateTime.UtcNow;
            return new AddressDTO(address);
        }

        public AddressDTO Get(int id)
        {
            var address = FindAddress(id);
            var addressDTO = new AddressDTO(address);
            return addressDTO;
        }

        public List<AddressDTO> GetAll()
        {
            var addressDTOs = new List<AddressDTO>();
            foreach (var address in this.dbcontext.Addresses.Include(a=>a.City))
            {
                var a = new AddressDTO(address);
                addressDTOs.Add(a);
            }
            return addressDTOs;
        }
        //TODO
        public Address Update(int id,Address model)
        {
            var address = FindAddress(id);
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            address = model;
            return address;
        }
        private Address FindAddress(int id)
        {
            var address = this.dbcontext
                              .Addresses
                              .Include(a => a.City)
                              .FirstOrDefault(a => a.Id == id);
            if (address == null)
            {
                throw new ArgumentNullException();
            }
            return address;
        }
    }
}
