﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Primitives;

public abstract class Entity
{
	public Guid Id { get; set; } = Guid.NewGuid();
}

