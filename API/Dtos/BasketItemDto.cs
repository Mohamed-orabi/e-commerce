using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public string Id{ get; set; }
        public List<CustomerBasketDto> Items { get; set; }
    }
}