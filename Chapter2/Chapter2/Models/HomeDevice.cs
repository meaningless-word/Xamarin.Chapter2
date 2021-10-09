﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2.Models
{
	class HomeDevice
	{
		public Guid id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string Description { get; set; }

		public HomeDevice(string name, string image = null, string description = null)
		{
			id = Guid.NewGuid();
			Name = name;
			Image = image;
			Description = description;
		}
	}
}
