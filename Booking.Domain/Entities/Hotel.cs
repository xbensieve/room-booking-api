﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Domain.Entities
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hotel name is required.")]
        [StringLength(256, ErrorMessage = "Hotel name must not exceed 256 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(512, ErrorMessage = "Address must not exceed 512 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City must not exceed 100 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(100, ErrorMessage = "Country must not exceed 100 characters.")]
        public string Country { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Description must not exceed 2000 characters.")]
        public string? Description { get; set; }

        [Range(0, 5)]
        public double AverageRating { get; set; } = 0;

        public int TotalReviews { get; set; } = 0;

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(15, ErrorMessage = "Phone number must not exceed 15 characters.")]
        public string PhoneNumber { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

        public virtual ICollection<HotelImage> Images { get; set; } = new List<HotelImage>();
    }
}
