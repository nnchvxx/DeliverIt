﻿using DeliverIt.Data;
using DeliverIt.Data.Models;
using DeliverIt.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverIt.Services.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly DeliverItContext dbContext;

        public ShipmentService(DeliverItContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Shipment Create(Shipment shipment)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Shipment> GetAll()
        {
            return dbContext.Shipments;
        }
        public Shipment Get(int id)
        {
            var shipment = dbContext.Shipments.FirstOrDefault(s => s.Id == id);
            if(shipment == null)
            {
                throw new ArgumentNullException();
            }
            return shipment;
        }
        public Shipment Update(int id, Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipment> GetBy(string filter, string type)
        {
            throw new NotImplementedException();
        }
    }
}