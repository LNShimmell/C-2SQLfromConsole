﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnect {
	public class User {

		public int Id { get; set; }
		public string Fname { get; set; }
		public string Lname { get; set; }
		public string Position { get; set; }
		public int PlayerNumb { get; set; }
		public int yearsplayed { get; set; }
		public decimal Salary { get; set; }

		public User() {

		}

	}
}
