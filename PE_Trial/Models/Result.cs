using System;
using System.Collections.Generic;

namespace PE_Trial.Models;

public partial class Result
{
    public string? StudentId { get; set; }

    public string? CourseId { get; set; }

    public int? Year { get; set; }

    public int? Semester { get; set; }

    public double? Mark { get; set; }

    public string? Grade { get; set; }
}
