namespace WebApp.Models.ViewModels
{
	public class CardGridVM
	{
		public IEnumerable<string> Categories { get; set; } = null!;
		public IEnumerable<CardGridItemVM> GridItems { get; set; } = null!;
		//public bool LoadMore { get; set; } = false;
	}
}
