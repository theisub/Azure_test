using DSIP_.Models;
using DSIP_.Services;
using System;

using System.Collections.Generic;
using Xunit;
using Moq;
namespace DSIP_Testing
{
    public class SimpleTests
    {

        private List<Item> _allItems = new List<Item>() 
        {
            new Item(){id = "1",itemName="test1",value = 11, itemMaster="master1"},
            new Item(){id = "2",itemName="test2",value = 22, itemMaster="master2"},
            new Item(){id = "3",itemName="test3",value = 33, itemMaster="master3"}
        };
        private Item oneItem = new Item() { id = "4", itemName = "test4", value = 44, itemMaster = "master4" };


        private ItemsDatabaseSettings settings = new ItemsDatabaseSettings() { ConnectionString = "mongodb://localhost:27017", DatabaseCollectionName = "Test", DatabaseName = "TestDB" };
        
        [Fact]
        public void GetAllItems()
        {
            var mock = new Mock<IItemService>();
       
            var test = mock.Setup(x => x.Get()).Returns(_allItems);

            IItemService mongoService = mock.Object;

            var items = mongoService.Get();
            var count = items.Count;

            Assert.Equal(3, count);

        }

        [Fact]
        public void GetCertainItem()
        {
            var mock = new Mock<IItemService>();

            var test = mock.Setup(x => x.Get(oneItem.id)).Returns(oneItem);

            IItemService mongoService = mock.Object;

            var item = mongoService.Get(oneItem.id);
            var id = item.id;

            Assert.Equal(oneItem.id, id);

        }

        [Fact]
        public void CreateItem()
        {
            var mock = new Mock<IItemService>();

            var test = mock.Setup(x => x.Create(oneItem)).Returns(oneItem);

            IItemService mongoService = mock.Object;

            var items = mongoService.Create(oneItem);
            var id = items.id;

            Assert.Equal("4",id);
        }
     
    }
}
