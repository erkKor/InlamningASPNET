namespace WebApp.Models.ViewModels
{
	public class CardGridVM
	{
		public IEnumerable<string>? Categories { get; set; } 
		public IEnumerable<CardGridItemVM> GridItems { get; set; } = null!;
	}
}
