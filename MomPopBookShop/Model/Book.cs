using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomPopBookShop.Model
{
	public class Book
	{
		public int Isbn { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Genre { get; set; }
		public int NumberInStock { get; set; }
	}
}
