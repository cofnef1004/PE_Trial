using System;
using System.Collections.Generic;

namespace PE_Trial.Models;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string? Name { get; set; }

    public byte? Credits { get; set; }
}
