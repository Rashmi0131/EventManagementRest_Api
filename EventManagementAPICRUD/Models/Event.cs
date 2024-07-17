using System;
using System.Collections.Generic;

namespace EventManagementAPICRUD.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Location { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Organizer { get; set; } = null!;
}
