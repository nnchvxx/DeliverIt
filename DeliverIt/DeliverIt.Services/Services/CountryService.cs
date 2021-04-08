﻿using DeliverIt.Data;
using DeliverIt.Data.Models;
using DeliverIt.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverIt.Services.Services
{
    public class CountryService : ICountryService
    {
        public string Get(int id)
        {
            var country = Database.Countries.FirstOrDefault(c => c.Id == id).Name;
            if(country == null)
            {
                throw new ArgumentNullException();
            }
            return country;
        }

        public IList<string> GetAll()
        {
            return Database.Countries.Select(c => c.Name).ToList();
        }
    }
}
