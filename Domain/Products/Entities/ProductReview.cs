using Domain.Common;

namespace Domain.Products.Entities;

public class ProductReview : Entity<Guid>
{
    public int Rating { get; private set; } = default!;
    public string Comment { get; private set; } = null!;
    public Guid CustomerId { get; private set; } = default;

    private ProductReview() { }

    public ProductReview(Guid id, int rating, string comment, Guid customerId)
    {
        Id = id;
        Rating = rating;
        Comment = comment;
        CustomerId = customerId;
    }

    public void UpdateComment(string newComment) => Comment = newComment;
    public void UpdateRating(int newRating) => Rating = newRating;
}
