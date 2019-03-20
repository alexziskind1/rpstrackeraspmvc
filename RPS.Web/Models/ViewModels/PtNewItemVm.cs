using RPS.Core.Models.Dto;
using RPS.Core.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RPS.Web.Models.Data
{
    public class PtNewItemVm
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }


        private readonly List<ItemTypeEnum> _itemTypes = new List<ItemTypeEnum> { ItemTypeEnum.Bug, ItemTypeEnum.Chore, ItemTypeEnum.Impediment, ItemTypeEnum.PBI };


        [Display(Name = "Type")]
        public ItemTypeEnum TypeStr { get; set; }

        public IEnumerable<SelectListItem> ItemTypes 
        {
            get { return new SelectList(_itemTypes, ItemTypeEnum.Bug); }
        }
        public PtNewItemVm()
        {
            TypeStr = ItemTypeEnum.Bug;
        }

        public PtNewItem ToPtNewItem()
        {
            return new PtNewItem
            {
                Title = Title,
                Description = Description,
                TypeStr = TypeStr
            };
        }
    }
}