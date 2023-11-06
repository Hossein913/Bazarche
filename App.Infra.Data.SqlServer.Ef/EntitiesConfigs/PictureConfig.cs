using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Common.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class PictureConfig : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.CreatedAt).HasColumnType("datetime");

        entity.HasData(
            //Categories
            new Picture { Id = 1 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "102140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 2 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "202140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 3 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "302140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 4 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "402140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 5 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "502140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 6 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "602140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 7 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "702140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 8 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "802140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 9 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "902140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 10 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "102140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            new Picture { Id = 11 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "112140ea60e0fd478b09b279976a095c95615b6_1656161174.png", IsDeleted = false  },
            //Profile
            new Picture { Id = 12 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "5522140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 13 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "5502140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 14 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "5512140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 15 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "5532140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            //Booth
            new Picture { Id = 16 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "9902140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 17 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "9912140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            //Product
            new Picture { Id = 18 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8802140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 19 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8812140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 20 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8822140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 21 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8832140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 22 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8842140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false  },
            new Picture { Id = 23 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8852140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false },
            new Picture { Id = 24 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8862140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false },
            new Picture { Id = 25 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8872140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false },
            new Picture { Id = 26 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8882140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false },
            new Picture { Id = 27 , CreatedAt = DateTime.Now , CreatedBy = null , ImageUrl = "8892140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", IsDeleted = false }
                               
            );
    }
}
