using System;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Context
{
        public class UserEntityModel
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public Guid PublicIdentifier { get; set; }
            [Required]
            public string? name { get; set; }
            [Required]
            public string? lastName { get; set; }
            [Required]
            public string? password { get; set; }
            [Required]
            public string? email { get; set; }
        }
    }


