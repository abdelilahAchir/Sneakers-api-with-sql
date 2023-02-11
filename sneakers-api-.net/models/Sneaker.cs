namespace sneakers_api_.net.models
{
	public class Sneaker
	{
		public int id { get; set; }
		public string brand { get; set; }
		public string model { get; set; }
		public string price { get; set; }
		public  virtual ICollection<Size> sizes { get; set; }
		public string gender { get; set; }
		public virtual ICollection<Color> colors { get; set; }
		public virtual ICollection<ImageUrl> images_urls { get; set; }
	}
}
