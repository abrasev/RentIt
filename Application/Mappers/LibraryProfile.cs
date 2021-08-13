﻿using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class LibraryProfile: Profile
    {
        public LibraryProfile()
        {
            CreateMap<Car, CarViewModel>().ReverseMap();
            CreateMap<Apartment, ApartmentViewModel>().ReverseMap();
            CreateMap<Rentee, RenteeViewModel>().ReverseMap();
        }
    }
}
