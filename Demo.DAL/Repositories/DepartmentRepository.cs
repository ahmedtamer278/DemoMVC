﻿using Demo.DAL.Data.Context;

namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicationDbContext context) : GenericRepository<Department>(context) , IDepartmentRepository
    {
        

    }
}
