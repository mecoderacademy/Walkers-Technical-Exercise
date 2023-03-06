using Microsoft.AspNetCore.Mvc;
using Walkers.UI.Server.Controllers;
using Walkers.UI.Server.Services;
using Walkers.UI.Shared;

namespace Walkers.Tests;
public class FizzBuzzControllerTest
{
    private FizzBuzzController fizzBuzzController;
    const string badRequestMessegeLessThanZero = "Number should be greater than 0";
    [SetUp]
    public void Setup()
    {
        fizzBuzzController = new FizzBuzzController();
    }
    
    [Test]
    public void Get_ValueIsZero_ShouldReturnBadRequest()
    {

        // Act
        var result = fizzBuzzController.Get(0);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
        var badRequestResult = actionResult.Result as BadRequestObjectResult;
        Assert.That(badRequestResult?.StatusCode, Is.EqualTo(400));
        Assert.That(badRequestResult?.Value, Is.EqualTo(badRequestMessegeLessThanZero));

    }


    [Test]
    public void Get_ValueIsNegative_ShouldReturnBadRequest()
    {
        // Act
        var result = fizzBuzzController.Get(-5);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
        var badRequestResult = actionResult.Result as BadRequestObjectResult;
        Assert.That(badRequestResult?.StatusCode, Is.EqualTo(400));
        Assert.That(badRequestResult?.Value, Is.EqualTo(badRequestMessegeLessThanZero));
    }

    [Test]
    public void Get_ValueIsMoreThanTwoHundred_ShouldReturnBadRequest()
    {
        // Act
        var result = fizzBuzzController.Get(201);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
        var badRequestResult = actionResult.Result as BadRequestObjectResult;
        Assert.That(badRequestResult?.StatusCode, Is.EqualTo(400));
        Assert.That(badRequestResult?.Value, Is.EqualTo(badRequestMessegeLessThanZero));
    }

    [Test]
    public void Get_ValueIsMultipleOfThree_ShouldReturnListWithWalkers()
    {
        // Act
        var result = fizzBuzzController.Get(3);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        var okRequestResult = actionResult.Result as OkObjectResult;
        var listOfValues = okRequestResult?.Value as IList<string>;

        Assert.That(okRequestResult?.StatusCode, Is.EqualTo(200));
        Assert.That(listOfValues, Is.Not.Null);
        Assert.That(listOfValues, Is.Not.Empty);
        Assert.That(listOfValues.Count, Is.EqualTo(3));
        Assert.That(listOfValues[0], Is.EqualTo("1"));
        Assert.That(listOfValues[1], Is.EqualTo("2"));
        Assert.That(listOfValues[2], Is.EqualTo("walkers".AddDayTag()));

    }

    [Test]
    public void Get_ValueIsMultipleOfFive_ShouldReturnListWithWalkersAndAssesment()
    {
        // Act
        var result = fizzBuzzController.Get(5);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        var okRequestResult = actionResult.Result as OkObjectResult;
        var listOfValues = okRequestResult?.Value as IList<string>;

        Assert.That(okRequestResult?.StatusCode, Is.EqualTo(200));
        Assert.That(listOfValues, Is.Not.Null);
        Assert.That(listOfValues, Is.Not.Empty);
        Assert.That(listOfValues.Count, Is.EqualTo(5));
        Assert.That(listOfValues[0], Is.EqualTo("1"));
        Assert.That(listOfValues[1], Is.EqualTo("2"));
        Assert.That(listOfValues[2], Is.EqualTo("walkers".AddDayTag()));
        Assert.That(listOfValues[3], Is.EqualTo("4"));
        Assert.That(listOfValues[4], Is.EqualTo("assesment".AddDayTag()));


    }

    [Test]
    public void Get_ValueIsMultipleOfThreeAndFive_ShouldReturnListWithWalkersAndAssesment()
    {
        // Act
        var result = fizzBuzzController.Get(15);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        var okRequestResult = actionResult.Result as OkObjectResult;
        var listOfValues = okRequestResult?.Value as IList<string>;

        Assert.That(okRequestResult?.StatusCode, Is.EqualTo(200));
        Assert.That(listOfValues, Is.Not.Null);
        Assert.That(listOfValues, Is.Not.Empty);
        Assert.That(listOfValues.Count, Is.EqualTo(15));
        Assert.That(listOfValues[0], Is.EqualTo("1"));
        Assert.That(listOfValues[1], Is.EqualTo("2"));
        Assert.That(listOfValues[2], Is.EqualTo("walkers".AddDayTag()));
        Assert.That(listOfValues[3], Is.EqualTo("4"));
        Assert.That(listOfValues[4], Is.EqualTo("assesment".AddDayTag()));
        Assert.That(listOfValues[14], Is.EqualTo("walkers-m assesment-m"));


    }

    [Test]
    public void Get_ValueIsThirty_ShouldReturnTwentyItems()
    {
        // Act
        var result = fizzBuzzController.Get(30);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        var okRequestResult = actionResult.Result as OkObjectResult;
        var listOfValues = okRequestResult?.Value as IList<string>;

        Assert.That(listOfValues.Count, Is.EqualTo(20));
        Assert.That(okRequestResult?.StatusCode, Is.EqualTo(200));
        Assert.That(listOfValues, Is.Not.Null);
        Assert.That(listOfValues, Is.Not.Empty);
    
    }

    [Test]
    public void Get_ValueIsSixtyStartsAtTwentyNextTwenty_ShouldReturnTwentyItemsAndSkipFirstTwenty()
    {
        // Act
        var result = fizzBuzzController.Get(60,20,20);
        var allItems=FizzBuzzService.GetFizzBuzzValues(60,0,60).ToList();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        var okRequestResult = actionResult.Result as OkObjectResult;
        var listOfValues = okRequestResult?.Value as IList<string>;
       
        Assert.That(listOfValues[1], Is.EqualTo("22"));
        Assert.That(listOfValues[17], Is.EqualTo("38"));
        Assert.That(listOfValues.Count, Is.EqualTo(20));
        Assert.That(okRequestResult?.StatusCode, Is.EqualTo(200));
        Assert.That(listOfValues, Is.Not.Null);
        Assert.That(listOfValues, Is.Not.Empty);

    }

    [Test]
    public void Get_ValueIsSixtyStartsCurrent80_ShouldReturnEmptyList()
    {
        // Act
        var result = fizzBuzzController.Get(60, 20, 20);
        var allItems = FizzBuzzService.GetFizzBuzzValues(60, 0, 60).ToList();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<string>>>(result);
        var actionResult = result as ActionResult<IEnumerable<string>>;
        Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        var okRequestResult = actionResult.Result as OkObjectResult;
        var listOfValues = okRequestResult?.Value as IList<string>;

        Assert.That(listOfValues, Is.Empty);
        Assert.That(okRequestResult?.StatusCode, Is.EqualTo(200));
   

    }
}
