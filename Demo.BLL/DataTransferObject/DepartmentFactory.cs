﻿using Demo.DAL.Models;

namespace Demo.BLL.DataTransferObject
{
    public static class DepartmentFactory
    {
        public static DepartmentResponse ToResponse(this Department department)
        {
            return new()
            {
                Code = department.Code,
                Name = department.Name,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                Description = department.Description,
                Id = department.Id
            };

        }

        public static DepartmentDetailsResponse ToDetails(this Department department)
        {
            return new()
            {
                Code = department.Code,
                Name = department.Name,
                Id = department.Id,
                Description = department.Description,
                CreatedOn = department.CreatedOn,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted,
                LastModifiedOn = department.LastModifiedOn
            };
        }

        public static Department ToRequest(this DepartmentRequest department) 
        {
            return new()
            {
                Code = department.Code,
                Description = department.Description,
                CreatedOn = department.CreatedOn,
                Name = department.Name
            };
        } public static Department ToRequestUpdate(this DepartmentUpdateRequest department) 
        {
            return new()
            {
                Code = department.Code,
                Description = department.Description,
                Id = department.Id,
                Name = department.Name,
                CreatedOn = department.CreatedOn
            };
        }

    }
}
