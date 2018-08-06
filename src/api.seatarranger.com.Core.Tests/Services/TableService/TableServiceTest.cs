using api.seatarranger.com.Core.Tests.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace api.seatarranger.com.Core.Tests.Services.TableService
{
    public class TableServiceTest : IClassFixture<ServiceFixtures>
    {
        private readonly ServiceFixtures services;

        public TableServiceTest(ServiceFixtures services)
        {
            this.services = services;
        }

        [Fact]
        public void Should_Create_Table()
        {
            var expected = true;
            var actual = true;

            try
            {
                this.services.tableService.CreateTable(new Models.TableEntity
                {
                    Id = 'E',
                    Capacity = 2
                });
            }
            catch
            {
                actual = false;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Retrieve_Table_After_Create()
        {
            this.services.tableService.CreateTable(new Models.TableEntity
            {
                Id = 'T',
                Capacity = 2
            });

            var expected = 'T';
            var actual = char.MinValue;

            try
            {
                var result = this.services.tableService
                    .GetTable('T');

                actual = result.Id;
            }
            catch { }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Retrieve_Tables_After_Create()
        {
            this.services.tableService.CreateTable(new Models.TableEntity
            {
                Id = 'A',
                Capacity = 1
            });

            this.services.tableService.CreateTable(new Models.TableEntity
            {
                Id = 'B',
                Capacity = 2
            });

            this.services.tableService.CreateTable(new Models.TableEntity
            {
                Id = 'C',
                Capacity = 3
            });

            var expected = 3;
            var actual = 0;

            try
            {
                var itemsToTest = this.services.tableService
                    .GetTables();

                actual = itemsToTest.Count;
            }
            catch { }

            Assert.True(expected <= actual);
        }

        [Fact]
        public void Should_Throw_Error_When_Invalid_Table()
        {
            Assert.Throws<Exception>(() =>
            {
                this.services.tableService.CreateTable(new Models.TableEntity());
            });
        }

        [Fact]
        public void Should_Throw_Error_When_Zero_Table_Capacity()
        {
            Assert.Throws<Exception>(() =>
            {
                this.services.tableService.CreateTable(new Models.TableEntity
                {
                    Id = 'A'
                });
            });
        }

        [Fact]
        public void Should_Throw_Error_When_Invalid_Table_Id()
        {
            Assert.Throws<Exception>(() =>
            {
                this.services.tableService.CreateTable(new Models.TableEntity
                {
                    Id = 'a'
                });
            });
        }

        [Fact]
        public void Should_Throw_Error_When_Retrieving_Item_Not_Defined()
        {
            Assert.Throws<Exception>(() =>
            {
                this.services.tableService.GetTable('Z');
            });
        }
    }
}