using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public partial class Material
{
    public int MaterialId { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public string? FileName { get; set; }

    public string? FileType { get; set; }

    public virtual ICollection<Ha> Has { get; set; } = new List<Ha>();
}
