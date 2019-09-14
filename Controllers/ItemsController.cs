using System;
using System.Collections.Generic;
using DSIP_.Models;
using DSIP_.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSIP_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get() =>
            _itemService.Get();

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        public ActionResult<Item> Get(string id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            _itemService.Create(item);

            return item;
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Item> Update(string id, Item itemIn)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemService.Update(id, itemIn);

            return itemIn;

        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult<Item> Remove(string id, Item itemIn)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {

                return NotFound();
            }

            _itemService.Remove(item.id);

            return itemIn;
        }
        

    }
}
