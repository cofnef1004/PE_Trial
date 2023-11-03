using System;
using System.Collections.Generic;

namespace PE_Trial.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Sex { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? DeptId { get; set; }

    public double? Scholarship { get; set; }

    public decimal? AverageScore { get; set; }

    public virtual Department? Dept { get; set; }
}
