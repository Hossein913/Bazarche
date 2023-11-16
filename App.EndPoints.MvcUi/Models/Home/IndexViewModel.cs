﻿using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.EndPoints.MvcUi.Models.Home
{
    public class IndexViewModel
    {
        public List<CategoryOutputDto> ParentCategories { get; set; }
        public List<CategoryOutputDto> ChildCategories { get; set; }
        public List<BoothOutputDto> boothOutputs { get; set; }

    }
}