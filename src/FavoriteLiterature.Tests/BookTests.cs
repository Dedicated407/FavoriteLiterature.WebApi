using System;
using FavoriteLiterature.Api.Entities;
using Xunit;

namespace FavoriteLiterature.Tests;

public class BookTests
{
    
    [Fact]
    public void CanChangeBookRating()
    {
        // Arrange

        // Act
        var book = new Book("Земля", Guid.NewGuid(), 2);
        book.Rating = 9;

        // Assert
        Assert.Equal(9, book.Rating);
    }
}