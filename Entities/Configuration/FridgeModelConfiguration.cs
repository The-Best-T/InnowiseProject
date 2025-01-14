﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData
            (
                new FridgeModel
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Beko RCSK 310M20",
                    Year = 2018
                },
                new FridgeModel
                {
                    Id = new Guid("c15120c7-8e1f-4e85-b7a1-93a1b6bee619"),
                    Name = "Tesler RC-55 White",
                    Year = 2019
                },
                new FridgeModel()
                {
                    Id = new Guid("3aca17c8-2554-49f0-b43f-cfaceb030d7f"),
                    Name = "Pozis RK-139 W",
                    Year = 2020
                });
        }
    }
}
