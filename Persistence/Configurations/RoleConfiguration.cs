using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            
            builder.HasData(
                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = "student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole
                {
                    Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "0e66e087-1317-49d8-aa55-8db35bfb3304",
                    Name = "LeadHOE",
                    NormalizedName = "LEADHOE"
                },
                 new IdentityRole
                 {
                     Id = "e5975de6-3ae3-4ac5-a15b-7f568009d05e",
                     Name = "HOE",
                     NormalizedName = "HOE"
                 },

                 new IdentityRole
                 {
                     Id = "5305a265-dde0-41fc-a981-620025f80563",
                     Name = "ContestCreator",
                     NormalizedName = "CONTESTCREATOR"
                 }
            );
        }
    }
}
