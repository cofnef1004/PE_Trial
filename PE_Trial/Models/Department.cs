using System;
using System.Collections.Generic;

namespace PE_Trial.Models;

public partial class Department
{
    public string DeptId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? NoOfStudents { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
