using ToyShop.Data;
using ToyShop.Repository;

namespace ToyStore.Tests;

public class UnitTest1
{
    private ToyRepository _toyRepo;

    public UnitTest1()
    {
        _toyRepo = new ToyRepository();
    }

    [Fact]
    public void GetToys_ShouldContain2Toys()
    {
        //Arrange
        Queue<Toy> toysInDb = _toyRepo.GetToys();
    
        //Act
        int expectedCount = 2;
        int actualCount = toysInDb.Count();

        //Assert
        Assert.Equal(expectedCount,actualCount);
    }

    [Fact]
    public void AddToy_ShouldReturnTrue()
    {
        //Arrange
        Toy toyData = new Toy("Shredder","The Villian", ToyType.ACTION_FIGURE, 18.99m);
    
        //Act
        bool isSuccess = _toyRepo.AddToy(toyData);

        //Assert
        Assert.True(isSuccess);
    }

    [Fact]
    public void AddToy_ShouldReturnFalse()
    {
         //Arrange
        Toy toyData = new Toy("Shredder","The Villian", 0, 18.99m);
    
        //Act
        bool isSuccess = _toyRepo.AddToy(toyData);

        //Assert
        Assert.False(isSuccess);
    }
}