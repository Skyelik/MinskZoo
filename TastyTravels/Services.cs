using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("services")]
public class Services
{
    [Key]
    public int Id { get; set; }
    [Column("nameServices")]
    public string NameServices { get; set; }
    [Column("servicesType")]
    public string ServicesType { get; set; }
    [Column("location")]
    public string Location { get; set; }
    [Column("eventDate")]
    public string EventDate { get; set; }
    [Column("price")]
    public double Price { get; set; }

    public Services() { }

    public Services(string nameServices, string servicesType, string location, string eventDate, double price)
    {
        NameServices = nameServices;
        ServicesType = servicesType;
        Location = location;
        EventDate = eventDate;
        Price = price;
    }
}

