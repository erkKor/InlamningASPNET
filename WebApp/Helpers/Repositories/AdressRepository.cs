﻿using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class AdressRepository : Repository<AdressEntity>
    {
        public AdressRepository(DataContext context) : base(context)
        {
        }
    }
}
