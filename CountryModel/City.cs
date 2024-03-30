using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CountryModel;

[Table("City")]
public partial class City
{
    public string Name;

    [Key]
    [Column("CityID")]
    public int CityId { get; set; }

    [Column(TypeName = "numeric(18, 4)")]
    public decimal Latitude { get; set; }

    [Column(TypeName = "numeric(18, 4)")]
    public decimal Longitude { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }
    [ForeignKey("CountryId")]

    [Column("Population")]
    public int Population { get; set; }

    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;

}
