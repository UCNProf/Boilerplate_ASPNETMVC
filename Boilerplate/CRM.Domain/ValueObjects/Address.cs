﻿using CRM.Domain.Common;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty; 

        private Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
        }

        public Address() { } //for ORM - DO NOT USE AS "NEW" - THAT WOULD BYPASS THE GUARD CLAUSES

        public static Result<Address> Create(string street, string city, string zipcode)
        {            
            Ensure.That(street, nameof(street)).IsNotNullOrEmpty();
            Ensure.That(city, nameof(city)).IsNotNullOrEmpty();
            Ensure.That(zipcode, nameof(zipcode)).IsNotNullOrEmpty();
            return Result.Ok<Address>(new Address(street, city, zipcode));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
        }
    }
}
